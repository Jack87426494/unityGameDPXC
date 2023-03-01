using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    //��ť������ı�
    public Text buttonText;
    //���水ť����
    public Button saveButton;
    //��Ϸ�Ĵ浵����
    public RankData rankData;
    //���а�����
    private RankDataList rankDataList;
    //����һ��Ҫɾ����ť��ʵ��
    public SaveButton otherOneBtn;

    private void Start()
    {
        //ͬ����ť��text����
        buttonText.text = rankData.cheakPointName /*+ " �÷� " + rankData.score + " ��ʱ " + rankData.time*/;
        saveButton.onClick.AddListener(() =>
        {
            MusicMgr.GetInstance().PlayeSound("Click",false);
            rankDataList = DataManager.Instance.rankDataDic;
             //�����б�
            ScrollRect scrollRect=UiManager.Instance.GetPanel<SaveChoosePanel>().scrollRect;

            if(rankData.reallySceneName=="1")
            {
                for (int i = 0; i < rankDataList.list.Count/2; i++)
                {
                    //ͬ��ÿһ���ؿ���ť�Ĺؿ�����
                    DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
                    GameObject saveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
                    saveObj.transform.SetParent(scrollRect.content, false);
                    SaveButton saveButton = saveObj.GetComponent<SaveButton>();
                    saveButton.rankData = rankDataList.list[i];
                }
                Destroy(gameObject);
                Destroy(otherOneBtn.gameObject);
            }
            else if(rankData.reallySceneName == "2")
            {
                for (int i = 3; i < rankDataList.list.Count; i++)
                {
                    //ͬ��ÿһ���ؿ���ť�Ĺؿ�����
                    DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
                    GameObject saveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
                    saveObj.transform.SetParent(scrollRect.content, false);
                    SaveButton saveButton = saveObj.GetComponent<SaveButton>();
                    saveButton.rankData = rankDataList.list[i];
                }
                Destroy(gameObject);
                Destroy(otherOneBtn.gameObject);
            }
            else
            {
                TipPanel tipPanel = UiManager.Instance.ShowPanel<TipPanel>();
                tipPanel.ChangeTipInfo("�Ƿ������Ϸ");
                UiManager.Instance.HidePanel<SaveChoosePanel>();
                tipPanel.SureClick(() =>
                {
                    if (rankData.reallySceneName == "")
                        SceneManager.LoadScene("Scene1");
                    else
                        SceneManager.LoadScene(rankData.reallySceneName);


                    //�ر�UI�������ı�������
                    MusicManager.Instance.isPlayMusic(false);
                    //��ʾ��Ϸ��ֵ���
                    UiManager.Instance.ShowPanel<GameDataPanel>();
                    //������UI�������
                    UiManager.Instance.HidePanel<BkPanel>();
                    //���ش浵���
                    UiManager.Instance.HidePanel<SaveChoosePanel>();
                    //������ʾ���
                    UiManager.Instance.HidePanel<TipPanel>();
                });
                tipPanel.CanselClick(() =>
                {
                    //������ʾ���
                    UiManager.Instance.HidePanel<TipPanel>();
                    //��ʾ�浵���
                    UiManager.Instance.ShowPanel<SaveChoosePanel>();
                });
            }
            
        });
    }
}
