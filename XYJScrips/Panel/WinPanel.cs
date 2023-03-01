using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class WinPanel : BasePanel
{
    //胜利提示文字
    public Text winText;
    //本关的关卡序号
    private int cheakPointNum;
    //本关卡面板上的名字
    private string cheakPointName;
    //本关的关卡场景名
    private string cheakSceneName;
    //下一关面板上的名字
    private string rNextCheakName;
    //下一关的关卡场景名
    private string rNextSceneName;
    //重新开始按钮
    public Button YesBtn;
    //返回游戏主界面按钮
    public Button NoBtn;
    protected override void Init()
    {

        GameDataPanel gameDataPanel = UiManager.Instance.GetPanel<GameDataPanel>();
        //保存本关卡游戏通关数据
        gameDataPanel.SaveCheakData(cheakPointNum, cheakPointName, cheakSceneName);
        //如果本关是第六关
        if (cheakPointNum == 5)
            winText.text = "挑战成功，点击返回主界面";
        else
        {
            winText.text = "挑战成功是否进入下一关。";
        }
            ////保存下一关的游戏通关数据
            //gameDataPanel.SaveCheakData(cheakPointNum + 1, rNextCheakName, rNextSceneName);

            YesBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //重新加载关卡
            SceneManager.LoadScene(rNextSceneName);
            //重置游戏面板上的信息
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //隐藏失败面板
            UiManager.Instance.HidePanel<WinPanel>();
        });
        NoBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //打开UI主场景的背景音乐
            MusicManager.Instance.isPlayMusic(true);
            //返回游戏主界面
            SceneManager.LoadScene("UI");
            //重置游戏面板上的信息
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //关闭游戏面板
            UiManager.Instance.HidePanel<GameDataPanel>();
            //显示主UI界面和背景图
            UiManager.Instance.ShowPanel<BkPanel>();
            UiManager.Instance.ShowPanel<MainPanel>();
            //隐藏失败面板
            UiManager.Instance.HidePanel<WinPanel>();
        });
        //开启面板时暂停游戏时间
        Time.timeScale = 0;
        ////播放胜利音效
        //DataManager.Instance.AutoSoundPlay("Win");
    }
   
    /// <summary>
    /// 设置关卡信息
    /// </summary>
    /// <param name="cheakPointName">实际本关的关卡场景名</param>
    public void SetCheakInfo( string cheakSceneName)
    {
        this.cheakSceneName = cheakSceneName;
        switch (cheakSceneName)
        {
           case "Scene1":
                cheakPointName = "拼字关卡一";
                rNextCheakName = "拼字关卡二";
                cheakPointNum = 0;
                rNextSceneName = "Scene2";
                break;
            case "Scene2":
                cheakPointName = "拼字关卡二";
                rNextCheakName = "拼字关卡三";
                cheakPointNum = 1;
                rNextSceneName = "Scene3";
                break;
            case "Scene3":
                cheakPointName = "拼字关卡三";
                rNextCheakName = "成语关卡一";
                cheakPointNum = 2;
                rNextSceneName = "Scene4";
                break;
            case "Scene4":
                cheakPointName = "成语关卡一";
                rNextCheakName = "成语关卡二";
                cheakPointNum = 3;
                rNextSceneName = "Scene5";
                break;
            case "Scene5":
                cheakPointName = "成语关卡二";
                rNextCheakName = "成语关卡三";
                rNextSceneName = "Scene6";
                cheakPointNum = 4;
                break;
            case "Scene6":
                cheakPointName = "成语关卡三";
                rNextSceneName = "UI";
                cheakPointNum = 5;
                break;
        }
    }

    //关闭面板时恢复游戏正常速度
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}

