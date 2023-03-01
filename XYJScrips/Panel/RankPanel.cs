using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RankPanel : BasePanel
{
    //���ذ�ť
    public Button bkBtn;
    //�����б�
    public ScrollRect scrollRect;
    //���а�����
    private RankDataList rankDataList;
    protected override void Init()
    {
        rankDataList = DataManager.Instance.rankDataDic;
        if (rankDataList.list.Count > 0)
        {
            for (int i = 0; i < rankDataList.list.Count; i++)
            {
                //ͬ��ÿһ���ؿ���ť�Ĺؿ�����
                DataManager.Instance.UpDataRankData(i, rankDataList.list[i]);
                GameObject rankObj = Instantiate(Resources.Load<GameObject>("UiPanel/RankContent"));
                rankObj.transform.SetParent(scrollRect.content, false);
                //ͬ�����а��ϵ�������ʾ
                rankObj.GetComponent<RankContent>().setInfo(rankDataList.list[i].cheakPointName,
                    rankDataList.list[i].time, rankDataList.list[i].score);
            }
        }
        bkBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //������Ϸ���
            UiManager.Instance.ShowPanel<MainPanel>();
            //���ش浵���
            UiManager.Instance.HidePanel<RankPanel>();
        });
    }
    public override void HideSelf(UnityAction action)
    {
        //ɾ��content����ҵİ�ť
        for (int i = 0; i < scrollRect.content.childCount; i++)
        {
            Destroy(scrollRect.content.GetChild(i).gameObject);
        }
        base.HideSelf(action);


    }
}
