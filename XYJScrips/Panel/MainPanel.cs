using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainPanel : BasePanel
{
    //开始游戏按钮
    public Button beginButton;
    //游戏设置按钮
    public Button settingBtn;
    //游戏指南按钮
    public Button setButton;
    //退出游戏按钮
    public Button exitButton;
    //排行榜按钮
    public Button rankBtn;
    //制作人名单
    public Button makerBtn;

    protected override void Init()
    {
        //点击开始游戏按钮时
        beginButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //进入选择难度面板
            UiManager.Instance.ShowPanel<SaveChoosePanel>();
            //隐藏主游戏界面面板
            UiManager.Instance.HidePanel<MainPanel>();
        });
        //点击游戏设置按钮时
        settingBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //隐藏主UI面板
            UiManager.Instance.HidePanel<MainPanel>();
                //显示游戏设置面板
                UiManager.Instance.ShowPanel<SettingPanel>();
        });
        //点击游戏指南按钮时
        setButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //隐藏主游戏界面面板
            UiManager.Instance.HidePanel<MainPanel>();
            //进入游戏设置面板
            UiManager.Instance.ShowPanel<GuidePanel>();
        });
        //点击退出游戏按钮时
        exitButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //显示提示面板
            TipPanel tipPanel = UiManager.Instance.ShowPanel<TipPanel>();
            //改变提示面板的内容
            tipPanel.ChangeTipInfo("是否退出游戏");
            //在提示面板中,点击确定按钮时执行的函数
            tipPanel.SureClick(() =>
            { 
                Application.Quit();
            });
            //在提示面板中，点击取消按钮时执行的函数
            tipPanel.CanselClick(() =>
            {
                //隐藏提示面板
                UiManager.Instance.HidePanel<TipPanel>();
            });
            ////退出游戏
            //Application.Quit();
        });
        rankBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //隐藏主游戏界面面板
            UiManager.Instance.HidePanel<MainPanel>();
            //进入排行榜界面
            UiManager.Instance.ShowPanel<RankPanel>();
        });
        makerBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //隐藏主游戏界面面板
            UiManager.Instance.HidePanel<MainPanel>();
            //进入游戏设置面板
            UiManager.Instance.ShowPanel<MakerPanel>();
        });
    }
}
