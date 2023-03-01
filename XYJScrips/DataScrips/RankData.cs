using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一次游戏的记录
public class RankData 
{
    //玩家分数
    public int score = 0;
    //玩家进行游戏时间
    public int time = 0;
    //关卡名字
    public string cheakPointName="";
    //实际关卡场景名字
    public string reallySceneName = "";
    //防止默然构造被顶掉
    public RankData()
    {

    }
    public RankData(int score,int time,string cheakPointName,string reallySceneName)
    {
        this.time = time;
        this.score = score;
        this.cheakPointName = cheakPointName;
        this.reallySceneName = reallySceneName;
    }
}
//玩家多次游戏的记录
public class RankDataList
{
    public List<RankData> list = new List<RankData>();
}
