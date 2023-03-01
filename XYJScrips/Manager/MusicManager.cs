using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������ڿؼ��ϵ�ʵ�ʸı�
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

    //�򿪹�����
    public void Open()
    {

    }

    /// <summary>
    /// ͬ��һ���������ݲ�����ʵ����
    /// </summary>
    private void UpdateMusicData()
    {
        MusicData musicData=DataManager.Instance.musicData;
        musicAudioSource.mute = !musicData.isOpenMusic;
        musicAudioSource.volume = musicData.musicValue;
    }

    /// <summary>
    /// �л����ŵ�����
    /// </summary>
    /// <param name="musicName"></param>
    public void ChangeMusic(string musicName)
    {
        musicAudioSource.clip = Resources.Load<AudioClip>("Music/" + musicName);
    }
    
    /// <summary>
    /// ���Ʊ������ֵĲ���
    /// </summary>
    /// <param name="isPlay"></param>
    public void isPlayMusic(bool isPlay)
    {
        if(isPlay)
            //��ʼ���ű�������
            musicAudioSource.Play();
        else
        //ֹͣ��������
        musicAudioSource.Stop();
    }


    //�������ֿ���
    public void SetOpenMusic(bool isOpen)
    {
        musicAudioSource.mute = !isOpen;
        DataManager.Instance.SetOpenMusic(isOpen);
    }
    //�������ִ�С
    public void SetMusicValue(float value)
    {
        musicAudioSource.volume = value;
        DataManager.Instance.SetMusicValue(value);
    }
}
