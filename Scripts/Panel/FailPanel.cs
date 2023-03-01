using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FailPanel : BasePanel
{
    //ʵ�ʹؿ���
    private string reallyCheakName; 
    //���¿�ʼ��ť
    public Button YesBtn;
    //������Ϸ�����水ť
    public Button NoBtn;
    protected override void Init()
    {
        
        YesBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //���¼��عؿ�
            SceneManager.LoadScene(reallyCheakName);
            //������Ϸ����ϵ���Ϣ
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //����ʧ�����
            UiManager.Instance.HidePanel<FailPanel>();
        });
        NoBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //������Ϸ������
            SceneManager.LoadScene("UI");
            //��UI�������ı�������
            MusicManager.Instance.isPlayMusic(true);
            //�ر���Ϸ���
            UiManager.Instance.HidePanel<GameDataPanel>();
            //��ʾ��UI����ͱ���ͼ
            UiManager.Instance.ShowPanel<BkPanel>();
            UiManager.Instance.ShowPanel<MainPanel>();
            //����ʧ�����
            UiManager.Instance.HidePanel<FailPanel>();
        });
        //�������ʱ��ͣ��Ϸʱ��
        Time.timeScale = 0;

        ////����ʧ����Ч
        //DataManager.Instance.AutoSoundPlay("Fail1");
    }
    /// <summary>
    /// ���ùؿ���Ϣ
    /// </summary>
    /// <param name="reallyCheakName">ʵ�ʹؿ���</param>
    public void SetCheakInfo(string reallyCheakName)
    {
        this.reallyCheakName = reallyCheakName;
    }
    //�ر����ʱ�ָ���Ϸ�����ٶ�
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}
