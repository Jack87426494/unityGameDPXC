using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 处理音乐在控件上的实际改变
/// </summary>
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject musicObj = new GameObject();
                musicObj.name = typeof(MusicManager).Name;
                musicObj.AddComponent<AudioListener>();
                instance = musicObj.AddComponent<MusicManager>();
            }
            return instance;
        }
    }

    private AudioSource musicAudioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        instance = this;
        musicAudioSource = gameObject.AddComponent<AudioSource>();
        ChangeMusic("Potato");
        musicAudioSource.Play();
        UpdateMusicData();
    }

    //打开管理器
    public void Open()
    {

    }

    /// <summary>
    /// 同步一次音乐数据并且真实播放
    /// </summary>
    private void UpdateMusicData()
    {
        MusicData musicData=DataManager.Instance.musicData;
        musicAudioSource.mute = !musicData.isOpenMusic;
        musicAudioSource.volume = musicData.musicValue;
    }

    /// <summary>
    /// 切换播放的音乐
    /// </summary>
    /// <param name="musicName"></param>
    public void ChangeMusic(string musicName)
    {
        musicAudioSource.clip = Resources.Load<AudioClip>("Music/" + musicName);
    }
    
    /// <summary>
    /// 控制背景音乐的播放
    /// </summary>
    /// <param name="isPlay"></param>
    public void isPlayMusic(bool isPlay)
    {
        if(isPlay)
            //开始播放背景音乐
            musicAudioSource.Play();
        else
        //停止播放音乐
        musicAudioSource.Stop();
    }


    //控制音乐开关
    public void SetOpenMusic(bool isOpen)
    {
        musicAudioSource.mute = !isOpen;
        DataManager.Instance.SetOpenMusic(isOpen);
    }
    //控制音乐大小
    public void SetMusicValue(float value)
    {
        musicAudioSource.volume = value;
        DataManager.Instance.SetMusicValue(value);
    }
}
