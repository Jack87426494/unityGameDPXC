using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveChoosePanel : BasePanel
{
    //���ذ�ť
    public Button backButton;
    //�����б�
    public ScrollRect scrollRect;
    //���а�����
    private RankDataList rankDataList;
    protected override void Init()
    {
        rankDataList = DataManager.Instance.rankDataDic;
        if (rankDataList.list.Count> 0)
        {
            //for (int i = 0; i < rankDataList.list.Count; i++)
            //{
            //    //ͬ��ÿһ���ؿ���ť�Ĺؿ�����
            //    DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
            //    GameObject saveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            //    saveObj.transform.SetParent(scrollRect.content, false);
            //    SaveButton saveButton = saveObj.GetComponent<SaveButton>();
            //    saveButton.rankData = rankDataList.list[i];
            //}

            //����ƴ�ְ�ť
            GameObject pingZiSaveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            pingZiSaveObj.transform.SetParent(scrollRect.content, false);
            SaveButton pingZiSaveButton = pingZiSaveObj.GetComponent<SaveButton>();
            pingZiSaveButton.rankData = new RankData(0, 0, "ƴ�ֹؿ�", "1");
            
            //���ɳ��ﰴť
            GameObject chengYuSaveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            chengYuSaveObj.transform.SetParent(scrollRect.content, false);
            SaveButton chengYuSaveButton = chengYuSaveObj.GetComponent<SaveButton>();
            chengYuSaveButton.rankData = new RankData(0, 0, "����ؿ�", "2");

            pingZiSaveButton.otherOneBtn = chengYuSaveButton;
            chengYuSaveButton.otherOneBtn = pingZiSaveButton;
        }
        backButton.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //������Ϸ���
            UiManager.Instance.ShowPanel<MainPanel>();
            //���ش浵���
            UiManager.Instance.HidePanel<SaveChoosePanel>();
        });
    }
    public override void HideSelf(UnityAction action)
    {
        //ɾ��content����ҵİ�ť
        for(int i=0;i<scrollRect.content.childCount;i++)
        {
            Destroy(scrollRect.content.GetChild(i).gameObject);
        }
        base.HideSelf(action);
    }
}
