using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    //返回按钮
    public Button goBkBtn;
    //音乐开关
    public Toggle musicToggle;
    //音效开关
    public Toggle soundToggle;
    //音乐滑块
    public Slider musicSlider;
    //音效滑块
    public Slider soundSlider;
     
    protected override void Init()
    {
        goBkBtn.onClick.AddListener(()=>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            //隐藏设置面板
            UiManager.Instance.HidePanel<SettingPanel>();
            //打开ui主面板
            UiManager.Instance.ShowPanel<MainPanel>();
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
    }

    public override void ShowSelf()
    {
        base.ShowSelf();
        //每次打开面板时同步一次面板上的音乐数据
        MusicData musicData= DataManager.Instance.musicData;
        musicToggle.isOn = musicData.isOpenMusic;
        soundToggle.isOn = musicData.isOpenSound;
        musicSlider.value = musicData.musicValue;
        soundSlider.value = musicData.soundValue;
    }
}
