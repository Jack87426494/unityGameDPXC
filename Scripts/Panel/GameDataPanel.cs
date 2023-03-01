using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataPanel : BasePanel
{
    //��ͣ��ť
    public Button pauseBtn;

    //���ʵ�ʵ÷�
    private int reallyScore=0;
    //��ҵ÷�Text
    public Text scoreText;

    //��ҵ���Ϸ����ʱ��Text
    public Text timeText;
    //��ҵ���Ϸʵ��ʱ��
    private float reallyTime;
    //��ʾ������ϵ�ʱ��
    private int gameTime;
    protected override void Init()
    {
        // ����ʱ��ͷ���
        ReplaceData();
        pauseBtn.onClick.AddListener(() =>
        {
            //����ͣ���,��false������ͣ��Ϸʱ�����������������¿��������
            UiManager.Instance.ShowPanel<PausePanel>(false);
            //���Ŵ�������Ч
            MusicMgr.GetInstance().PlayeSound("Pause1", false);
        });
    }
    /// <summary>
    /// ����ʱ��ͷ���
    /// </summary>
    public void ReplaceData()
    {
        reallyTime = 0;
        reallyScore = 0;
        //��������ϵķ���δͬ��
        scoreText.text = "����:" + reallyScore;
    }
    /// <summary>
    /// ������Ϸʱ����Update�������
    /// </summary>
    public void UpdateGameTime()
    {
        reallyTime += Time.deltaTime;
        gameTime = (int)reallyTime;
        timeText.text = "ʱ��" + ":" + gameTime;
    }
    /// <summary>
    /// �ӷ�
    /// </summary>
    /// <param name="scoreNum">Ҫ�ӵķ���</param>
    /// <param name="sceneNum">�������</param>
    public void AddScore(int scoreNum)
    {
        reallyScore += scoreNum;
        scoreText.text = "����:"+reallyScore;
    }
    /// <summary>
    /// ������а����ݣ������浽����
    /// </summary>
    /// <param name="cheakPointName">�ؿ�����ϵ�����</param>
    /// <param name="reallySceneName">ʵ�ʱ���ؿ��ĳ�����</param>
    /// <param name="cheakPointNum">�ؿ����</param>
    public void SaveCheakData(int cheakPointNum,string cheakPointName,string reallySceneName)
    {
        print("��������");
        DataManager.Instance.AddRankData(cheakPointNum, reallyScore, gameTime, cheakPointName, reallySceneName);
    }

    protected override void Update()
    {
        base.Update();
        UpdateGameTime();
    }
}
