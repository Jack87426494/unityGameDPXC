using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RankPanel : BasePanel
{
    //返回按钮
    public Button bkBtn;
    //储存列表
    public ScrollRect scrollRect;
    //排行榜数据
    private RankDataList rankDataList;
    protected override void Init()
    {
        rankDataList = DataManager.Instance.rankDataDic;
        if (rankDataList.list.Count > 0)
        {
            for (int i = 0; i < rankDataList.list.Count; i++)
            {
                //同步每一个关卡按钮的关卡数据
                DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
                GameObject rankObj = Instantiate(Resources.Load<GameObject>("UiPanel/RankContent"));
                rankObj.transform.SetParent(scrollRect.content, false);
                //同步排行榜上的数据显示
                rankObj.GetComponent<RankContent>().setInfo(rankDataList.list[i].cheakPointName,
                    rankDataList.list[i].time, rankDataList.list[i].score);
            }
        }
        bkBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //打开主游戏面板
            UiManager.Instance.ShowPanel<MainPanel>();
            //隐藏存档面板
            UiManager.Instance.HidePanel<RankPanel>();
        });
    }
    public override void HideSelf(UnityAction action)
    {
        //删除content下面挂的按钮
        for (int i = 0; i < scrollRect.content.childCount; i++)
        {
            Destroy(scrollRect.content.GetChild(i).gameObject);
        }
        base.HideSelf(action);


    }
}
