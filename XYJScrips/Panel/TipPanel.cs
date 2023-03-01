using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TipPanel : BasePanel
{
    //ȡ����ť
    public Button canselButton;
    //ȷ����ť
    public Button sureButton;
    //��ʾ����
    public Text tipText;
    //����ǻ��߷�
    private bool isSure;
    //���ȷ�ϰ�ť��ʱ��ִ�еĺ���
    private UnityAction sureAction;
    //���ȷ��ȡ����ʱ��ִ�еĺ���
    private UnityAction canselAction;
    protected override void Init()
    {
        canselButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            canselAction?.Invoke();
            canselAction = null;
        });
        sureButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            sureAction?.Invoke();
            sureAction = null;
        });
    }
    //�ı���ʾ����
    public void ChangeTipInfo(string info)
    {
        tipText.text = info;
    }
    //��������ί�У����ȷ����ťʱִ��
    public void SureClick(UnityAction unityAction)
    {
            sureAction += unityAction;
    }
    //��������ί�У����ȡ����ťʱִ��
    public void CanselClick(UnityAction unityAction)
    {
        canselAction += unityAction;
    }
}
