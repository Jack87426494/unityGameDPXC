using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveChoosePanel : BasePanel
{
    //返回按钮
    public Button backButton;
    //储存列表
    public ScrollRect scrollRect;
    //排行榜数据
    private RankDataList rankDataList;
    protected override void Init()
    {
        rankDataList = DataManager.Instance.rankDataDic;
        if (rankDataList.list.Count> 0)
        {
            //for (int i = 0; i < rankDataList.list.Count; i++)
            //{
            //    //同步每一个关卡按钮的关卡数据
            //    DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
            //    GameObject saveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            //    saveObj.transform.SetParent(scrollRect.content, false);
            //    SaveButton saveButton = saveObj.GetComponent<SaveButton>();
            //    saveButton.rankData = rankDataList.list[i];
            //}

            //生成拼字按钮
            GameObject pingZiSaveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            pingZiSaveObj.transform.SetParent(scrollRect.content, false);
            SaveButton pingZiSaveButton = pingZiSaveObj.GetComponent<SaveButton>();
            pingZiSaveButton.rankData = new RankData(0, 0, "拼字关卡", "1");
            
            //生成成语按钮
            GameObject chengYuSaveObj = Instantiate(Resources.Load<GameObject>("UiPanel/SaveButton"));
            chengYuSaveObj.transform.SetParent(scrollRect.content, false);
            SaveButton chengYuSaveButton = chengYuSaveObj.GetComponent<SaveButton>();
            chengYuSaveButton.rankData = new RankData(0, 0, "成语关卡", "2");

            pingZiSaveButton.otherOneBtn = chengYuSaveButton;
            chengYuSaveButton.otherOneBtn = pingZiSaveButton;
        }
        backButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //打开主游戏面板
            UiManager.Instance.ShowPanel<MainPanel>();
            //隐藏存档面板
            UiManager.Instance.HidePanel<SaveChoosePanel>();
        });
    }
    public override void HideSelf(UnityAction action)
    {
        //删除content下面挂的按钮
        for(int i=0;i<scrollRect.content.childCount;i++)
        {
            Destroy(scrollRect.content.GetChild(i).gameObject);
        }
        base.HideSelf(action);
    }
}
