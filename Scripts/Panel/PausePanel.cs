using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    //X按钮
    public Button xBtn;
    //音乐开关
    public Toggle musicToggle;
    //音效开关
    public Toggle soundToggle;
    //音乐滑块
    public Slider musicSlider;
    //音效滑块
    public Slider soundSlider;
    //返回游戏按钮
    public Button goGameBtn;
    //返回主游戏界面按钮
    public Button goBkBtn;

    protected override void Init()
    {
        //暂停游戏音乐
        MusicMgr.GetInstance().PauseBKMusic();
        //禁止键盘控制
        GameManager.GetInstance().inputStop = true;
        //每次打开面板时同步一次面板上的音乐数据
        UpdateMusicData();

        xBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //隐藏暂停面板
            UiManager.Instance.HidePanel<PausePanel>();
            //解触键盘控制
            GameManager.GetInstance().inputStop = false;
            //播放游戏场景背景音乐
            MusicMgr.GetInstance().PlayBKMusic("Music" + SceneManager.GetActiveScene().name);
        });

        //将面板上调整的数据同步到数据管理类以及磁盘中
        musicToggle.onValueChanged.AddListener((isOpen) =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            MusicManager.Instance.SetOpenMusic(isOpen);
        });
        soundToggle.onValueChanged.AddListener((isOpen) =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            DataManager.Instance.SetOpenSound(isOpen);
        });
        musicSlider.onValueChanged.AddListener((value) =>
        {
            MusicManager.Instance.SetMusicValue(value);
        });
        soundSlider.onValueChanged.AddListener((value) =>
        {
            DataManager.Instance.SetSoundValue(value);
        });
        goGameBtn.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //隐藏暂停面板
            UiManager.Instance.HidePanel<PausePanel>();
            //播放游戏场景背景音乐
            MusicMgr.GetInstance().PlayBKMusic("Music"+SceneManager.GetActiveScene().name);
            //解触键盘控制
            GameManager.GetInstance().inputStop = false;
        });
        goBkBtn.onClick.AddListener(() =>
        {

            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //关闭游戏面板
            UiManager.Instance.HidePanel<GameDataPanel>();
            //跳转场景到游戏UI场景
            SceneManager.LoadScene("UI");
            //打开UI主场景的背景音乐
            MusicManager.Instance.isPlayMusic(true);
            //隐藏暂停面板
            UiManager.Instance.HidePanel<PausePanel>();
            //打开ui背景面板
            UiManager.Instance.ShowPanel<BkPanel>();
            //打开ui主面板
            UiManager.Instance.ShowPanel<MainPanel>();
            //解触键盘控制
            GameManager.GetInstance().inputStop = false;

        });
        //开启面板时暂停游戏时间
        Time.timeScale = 0;
    }
    /// <summary>
    /// 同步一次面板上的音乐数据
    /// </summary>
    public void UpdateMusicData()
    {
        //每次打开面板时同步一次面板上的音乐数据
        MusicData musicData = DataManager.Instance.musicData;
        musicToggle.isOn = musicData.isOpenMusic;
        soundToggle.isOn = musicData.isOpenSound;
        musicSlider.value = musicData.musicValue;
        soundSlider.value = musicData.soundValue;
    }
    //关闭面板时恢复游戏正常速度
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}
