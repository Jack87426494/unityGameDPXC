using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataPanel : BasePanel
{
    //暂停按钮
    public Button pauseBtn;

    //玩家实际得分
    private int reallyScore=0;
    //玩家得分Text
    public Text scoreText;

    //玩家的游戏进行时间Text
    public Text timeText;
    //玩家的游戏实际时间
    private float reallyTime;
    //显示在面板上的时间
    private int gameTime;
    protected override void Init()
    {
        // 重置时间和分数
        ReplaceData();
        pauseBtn.onClick.AddListener(() =>
        {
            //打开暂停面板,填false避免暂停游戏时界面显隐卡主，导致看不到面板
            UiManager.Instance.ShowPanel<PausePanel>(false);
            //播放打开面板的音效
            MusicMgr.GetInstance().PlayeSound("Pause1", false);
        });
    }
    /// <summary>
    /// 重置时间和分数
    /// </summary>
    public void ReplaceData()
    {
        reallyTime = 0;
        reallyScore = 0;
        //避免面板上的分数未同步
        scoreText.text = "分数:" + reallyScore;
    }
    /// <summary>
    /// 更新游戏时间在Update里面调用
    /// </summary>
    public void UpdateGameTime()
    {
        reallyTime += Time.deltaTime;
        gameTime = (int)reallyTime;
        timeText.text = "时间" + ":" + gameTime;
    }
    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="scoreNum">要加的分数</param>
    /// <param name="sceneNum">场景序号</param>
    public void AddScore(int scoreNum)
    {
        reallyScore += scoreNum;
        scoreText.text = "分数:"+reallyScore;
    }
    /// <summary>
    /// 添加排行榜数据，并保存到磁盘
    /// </summary>
    /// <param name="cheakPointName">关卡面板上的名字</param>
    /// <param name="reallySceneName">实际保存关卡的场景名</param>
    /// <param name="cheakPointNum">关卡序号</param>
    public void SaveCheakData(int cheakPointNum,string cheakPointName,string reallySceneName)
    {
        print("保存数据");
        DataManager.Instance.AddRankData(cheakPointNum, reallyScore, gameTime, cheakPointName, reallySceneName);
    }

    protected override void Update()
    {
        base.Update();
        UpdateGameTime();
    }
}
