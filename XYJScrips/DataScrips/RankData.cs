using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//һ����Ϸ�ļ�¼
public class RankData 
{
    //��ҷ���
    public int score = 0;
    //��ҽ�����Ϸʱ��
    public int time = 0;
    //�ؿ�����
    public string cheakPointName="";
    //ʵ�ʹؿ���������
    public string reallySceneName = "";
    //��ֹĬȻ���챻����
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
//��Ҷ����Ϸ�ļ�¼
public class RankDataList
{
    public List<RankData> list = new List<RankData>();
}
