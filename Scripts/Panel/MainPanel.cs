using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainPanel : BasePanel
{
    //��ʼ��Ϸ��ť
    public Button beginButton;
    //��Ϸ���ð�ť
    public Button settingBtn;
    //��Ϸָ�ϰ�ť
    public Button setButton;
    //�˳���Ϸ��ť
    public Button exitButton;
    //���а�ť
    public Button rankBtn;
    //����������
    public Button makerBtn;

    protected override void Init()
    {
        //�����ʼ��Ϸ��ťʱ
        beginButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //����ѡ���Ѷ����
            UiManager.Instance.ShowPanel<SaveChoosePanel>();
            //��������Ϸ�������
            UiManager.Instance.HidePanel<MainPanel>();
        });
        //�����Ϸ���ð�ťʱ
        settingBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //������UI���
            UiManager.Instance.HidePanel<MainPanel>();
                //��ʾ��Ϸ�������
                UiManager.Instance.ShowPanel<SettingPanel>();
        });
        //�����Ϸָ�ϰ�ťʱ
        setButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //��������Ϸ�������
            UiManager.Instance.HidePanel<MainPanel>();
            //������Ϸ�������
            UiManager.Instance.ShowPanel<GuidePanel>();
        });
        //����˳���Ϸ��ťʱ
        exitButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //��ʾ��ʾ���
            TipPanel tipPanel = UiManager.Instance.ShowPanel<TipPanel>();
            //�ı���ʾ��������
            tipPanel.ChangeTipInfo("�Ƿ��˳���Ϸ");
            //����ʾ�����,���ȷ����ťʱִ�еĺ���
            tipPanel.SureClick(() =>
            { 
                Application.Quit();
            });
            //����ʾ����У����ȡ����ťʱִ�еĺ���
            tipPanel.CanselClick(() =>
            {
                //������ʾ���
                UiManager.Instance.HidePanel<TipPanel>();
            });
            ////�˳���Ϸ
            //Application.Quit();
        });
        rankBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //��������Ϸ�������
            UiManager.Instance.HidePanel<MainPanel>();
            //�������а����
            UiManager.Instance.ShowPanel<RankPanel>();
        });
        makerBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //��������Ϸ�������
            UiManager.Instance.HidePanel<MainPanel>();
            //������Ϸ�������
            UiManager.Instance.ShowPanel<MakerPanel>();
        });
    }
}
