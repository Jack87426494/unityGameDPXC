using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    //���ذ�ť
    public Button goBkBtn;
    //���ֿ���
    public Toggle musicToggle;
    //��Ч����
    public Toggle soundToggle;
    //���ֻ���
    public Slider musicSlider;
    //��Ч����
    public Slider soundSlider;
     
    protected override void Init()
    {
        goBkBtn.onClick.AddListener(()=>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //�����������
            UiManager.Instance.HidePanel<SettingPanel>();
            //��ui�����
            UiManager.Instance.ShowPanel<MainPanel>();
        });

        //������ϵ���������ͬ�������ݹ������Լ�������
        musicToggle.onValueChanged.AddListener((isOpen) =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            MusicManager.Instance.SetOpenMusic(isOpen);
        });
        soundToggle.onValueChanged.AddListener((isOpen) =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
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
        //ÿ�δ����ʱͬ��һ������ϵ���������
        MusicData musicData= DataManager.Instance.musicData;
        musicToggle.isOn = musicData.isOpenMusic;
        soundToggle.isOn = musicData.isOpenSound;
        musicSlider.value = musicData.musicValue;
        soundSlider.value = musicData.soundValue;
    }
}
