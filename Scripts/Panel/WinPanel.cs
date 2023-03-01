using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class WinPanel : BasePanel
{
    //ʤ����ʾ����
    public Text winText;
    //���صĹؿ����
    private int cheakPointNum;
    //���ؿ�����ϵ�����
    private string cheakPointName;
    //���صĹؿ�������
    private string cheakSceneName;
    //��һ������ϵ�����
    private string rNextCheakName;
    //��һ�صĹؿ�������
    private string rNextSceneName;
    //���¿�ʼ��ť
    public Button YesBtn;
    //������Ϸ�����水ť
    public Button NoBtn;
    protected override void Init()
    {

        GameDataPanel gameDataPanel = UiManager.Instance.GetPanel<GameDataPanel>();
        //���汾�ؿ���Ϸͨ������
        gameDataPanel.SaveCheakData(cheakPointNum, cheakPointName, cheakSceneName);
        //��������ǵ�����
        if (cheakPointNum == 5)
            winText.text = "��ս�ɹ����������������";
        else
        {
            winText.text = "��ս�ɹ��Ƿ������һ�ء�";
        }
            ////������һ�ص���Ϸͨ������
            //gameDataPanel.SaveCheakData(cheakPointNum + 1, rNextCheakName, rNextSceneName);

            YesBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //���¼��عؿ�
            SceneManager.LoadScene(rNextSceneName);
            //������Ϸ����ϵ���Ϣ
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //����ʧ�����
            UiManager.Instance.HidePanel<WinPanel>();
        });
        NoBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //��UI�������ı�������
            MusicManager.Instance.isPlayMusic(true);
            //������Ϸ������
            SceneManager.LoadScene("UI");
            //������Ϸ����ϵ���Ϣ
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //�ر���Ϸ���
            UiManager.Instance.HidePanel<GameDataPanel>();
            //��ʾ��UI����ͱ���ͼ
            UiManager.Instance.ShowPanel<BkPanel>();
            UiManager.Instance.ShowPanel<MainPanel>();
            //����ʧ�����
            UiManager.Instance.HidePanel<WinPanel>();
        });
        //�������ʱ��ͣ��Ϸʱ��
        Time.timeScale = 0;
        ////����ʤ����Ч
        //DataManager.Instance.AutoSoundPlay("Win");
    }
   
    /// <summary>
    /// ���ùؿ���Ϣ
    /// </summary>
    /// <param name="cheakPointName">ʵ�ʱ��صĹؿ�������</param>
    public void SetCheakInfo( string cheakSceneName)
    {
        this.cheakSceneName = cheakSceneName;
        switch (cheakSceneName)
        {
           case "Scene1":
                cheakPointName = "ƴ�ֹؿ�һ";
                rNextCheakName = "ƴ�ֹؿ���";
                cheakPointNum = 0;
                rNextSceneName = "Scene2";
                break;
            case "Scene2":
                cheakPointName = "ƴ�ֹؿ���";
                rNextCheakName = "ƴ�ֹؿ���";
                cheakPointNum = 1;
                rNextSceneName = "Scene3";
                break;
            case "Scene3":
                cheakPointName = "ƴ�ֹؿ���";
                rNextCheakName = "����ؿ�һ";
                cheakPointNum = 2;
                rNextSceneName = "Scene4";
                break;
            case "Scene4":
                cheakPointName = "����ؿ�һ";
                rNextCheakName = "����ؿ���";
                cheakPointNum = 3;
                rNextSceneName = "Scene5";
                break;
            case "Scene5":
                cheakPointName = "����ؿ���";
                rNextCheakName = "����ؿ���";
                rNextSceneName = "Scene6";
                cheakPointNum = 4;
                break;
            case "Scene6":
                cheakPointName = "����ؿ���";
                rNextSceneName = "UI";
                cheakPointNum = 5;
                break;
        }
    }

    //�ر����ʱ�ָ���Ϸ�����ٶ�
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}

