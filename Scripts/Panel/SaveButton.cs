using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    //按钮上面的文本
    public Text buttonText;
    //储存按钮本身
    public Button saveButton;
    //游戏的存档数据
    public RankData rankData;
    //排行榜数据
    private RankDataList rankDataList;
    //另外一个要删除按钮的实例
    public SaveButton otherOneBtn;

    private void Start()
    {
        //同步按钮的text数据
        buttonText.text = rankData.cheakPointName /*+ " 得分 " + rankData.score + " 用时 " + rankData.time*/;
        saveButton.onClick.AddListener(() =>
        {
            MusicMgr.GetInstance().PlayeSound("Click",false);
            rankDataList = DataManager.Instance.rankDataDic;
             //储存列表
            ScrollRect scrollRect=UiManager.Instance.GetPanel<SaveChoosePanel>().scrollRect;

            if(rankData.reallySceneName=="1")
            {
                for (int i = 0; i < rankDataList.list.Count/2; i++)
                {
                    //同步每一个关卡按钮的关卡数据
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
                    //同步每一个关卡按钮的关卡数据
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
                tipPanel.ChangeTipInfo("是否进入游戏");
                UiManager.Instance.HidePanel<SaveChoosePanel>();
                tipPanel.SureClick(() =>
                {
                    if (rankData.reallySceneName == "")
                        SceneManager.LoadScene("Scene1");
                    else
                        SceneManager.LoadScene(rankData.reallySceneName);


                    //关闭UI主场景的背景音乐
                    MusicManager.Instance.isPlayMusic(false);
                    //显示游戏数值面板
                    UiManager.Instance.ShowPanel<GameDataPanel>();
                    //隐藏主UI背景面板
                    UiManager.Instance.HidePanel<BkPanel>();
                    //隐藏存档面板
                    UiManager.Instance.HidePanel<SaveChoosePanel>();
                    //隐藏提示面板
                    UiManager.Instance.HidePanel<TipPanel>();
                });
                tipPanel.CanselClick(() =>
                {
                    //隐藏提示面板
                    UiManager.Instance.HidePanel<TipPanel>();
                    //显示存档面板
                    UiManager.Instance.ShowPanel<SaveChoosePanel>();
                });
            }
            
        });
    }
}
