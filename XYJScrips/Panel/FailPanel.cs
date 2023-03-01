using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FailPanel : BasePanel
{
    //实际关卡名
    private string reallyCheakName; 
    //重新开始按钮
    public Button YesBtn;
    //返回游戏主界面按钮
    public Button NoBtn;
    protected override void Init()
    {
        
        YesBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //重新加载关卡
            SceneManager.LoadScene(reallyCheakName);
            //重置游戏面板上的信息
            UiManager.Instance.GetPanel<GameDataPanel>().ReplaceData();
            //隐藏失败面板
            UiManager.Instance.HidePanel<FailPanel>();
        });
        NoBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //返回游戏主界面
            SceneManager.LoadScene("UI");
            //打开UI主场景的背景音乐
            MusicManager.Instance.isPlayMusic(true);
            //关闭游戏面板
            UiManager.Instance.HidePanel<GameDataPanel>();
            //显示主UI界面和背景图
            UiManager.Instance.ShowPanel<BkPanel>();
            UiManager.Instance.ShowPanel<MainPanel>();
            //隐藏失败面板
            UiManager.Instance.HidePanel<FailPanel>();
        });
        //开启面板时暂停游戏时间
        Time.timeScale = 0;

        ////播放失败音效
        //DataManager.Instance.AutoSoundPlay("Fail1");
    }
    /// <summary>
    /// 设置关卡信息
    /// </summary>
    /// <param name="reallyCheakName">实际关卡名</param>
    public void SetCheakInfo(string reallyCheakName)
    {
        this.reallyCheakName = reallyCheakName;
    }
    //关闭面板时恢复游戏正常速度
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}
