using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager:MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance 
    {
        get
        {
            if(instance==null)
            {
                GameObject dataObj = new GameObject();
                dataObj.name = typeof(DataManager).Name;
                instance=dataObj.AddComponent<DataManager>();
            }
            return instance;
        }
    }

    //���а�����
    public RankDataList rankDataDic;
    //��������
    public MusicData musicData;
    //��Чaudiosouce ��list
    private List<AudioSource> audioSourcesList = new List<AudioSource>();
    private void Awake()
    {
        ////�����ע�͹�������һ����Ϸ���ݸ�ʽ����
        //ReplaceData();
        //DontDestroyOnLoad(this.gameObject);
        instance = this;
        //��Ϸһ��ʼ�ʹӴ����϶�ȡ���а�����
        rankDataDic = JsonMgr.Instance.LoadData<RankDataList>("Rank");
        //������а�û������
        if(rankDataDic==null)
        {
            rankDataDic = new RankDataList();
            rankDataDic.list.Add(new RankData( 0, 0, "ƴ�ֹؿ�һ", ""));
            rankDataDic.list.Add(new RankData(0, 0, "ƴ�ֹؿ���", "Scene2"));
            rankDataDic.list.Add(new RankData(0, 0, "ƴ�ֹؿ���", "Scene3"));
            rankDataDic.list.Add(new RankData(0, 0, "����ؿ�һ", "Scene4"));
            rankDataDic.list.Add(new RankData(0, 0, "����ؿ���", "Scene5"));
            rankDataDic.list.Add(new RankData(0, 0, "����ؿ���", "Scene6"));
            //�������а����ݵ�������
            JsonMgr.Instance.SaveData(rankDataDic, "Rank");
        }
        //��Ϸһ��ʼ�ʹӴ����϶�ȡ��������
        musicData = JsonMgr.Instance.LoadData<MusicData>("Music");
        //����������ݻ�û�б����
        if(musicData==null)
        {
            musicData = new MusicData
            {
                isOpenMusic = true,
                isOpenSound = true,
                musicValue = 1,
                soundValue = 1
            };
            //���ĺ��������浽����
            JsonMgr.Instance.SaveData(musicData, "Music");
        }
    }
    /// <summary>
    /// ������а�����
    /// </summary>
    /// <param name="cheakPoint">�ؿ����</param>
    /// <param name="score">����ڱ��ؿ���õķ���</param>
    /// <param name="time">����ڱ��ؿ����е�ʱ��</param>
    /// <param name="cheakPointName">����Ϸѡ���������ʾ�Ĺؿ�����</param>
    /// <param name="reallySceneName">ʵ�ʵ���Ϸ������Ӧ������</param>
    public void AddRankData(int cheakPoint,int score,int time,string cheakPointName,string reallySceneName)
    {
        //�������Ĺؿ����ݣ�֮ǰ�Ѿ�����������ݣ��Ƚ������ݵķ�����ԭ���ķ�����С����������������Ǹ�
        if (rankDataDic.list.Count>cheakPoint)
        {
            if (rankDataDic.list[cheakPoint].score < score)
            {
                rankDataDic.list[cheakPoint] = new RankData(score, time,cheakPointName,reallySceneName);
            }
        }
        //����ֱ�ӱ���һ���ؿ���¼����
        else
        {
            rankDataDic.list.Add(new RankData(score, time,cheakPointName,reallySceneName));
        }
        //�������а����ݵ�������
        JsonMgr.Instance.SaveData(rankDataDic,"Rank");
    }
    /// <summary>
    /// ͬ��һ�����а������
    /// </summary>
    /// <param name="cheakPoint">�ؿ����</param>
    /// <param name="rankData">�˹ؿ���Ҫͬ������������</param>
    public void UpDataRankData(int cheakPoint,RankData rankData)
    {
        //������ݿ��������������
        if (rankDataDic.list[cheakPoint] != null)
        {
            rankData.cheakPointName = rankDataDic.list[cheakPoint].cheakPointName;
            rankData.reallySceneName = rankDataDic.list[cheakPoint].reallySceneName;
            rankData.score = rankDataDic.list[cheakPoint].score;
            rankData.time = rankDataDic.list[cheakPoint].time;
        }
        else
        {
            rankData.cheakPointName ="δ�����ؿ�";
            rankData.reallySceneName = "";
            rankData.score =0;
            rankData.time = 0;
        }
    }
/// <summary>
/// ��ʽ����������
/// </summary>
    public void ReplaceData()
    {
        rankDataDic = new RankDataList();
        rankDataDic.list.Add(new RankData(0, 0, "ƴ�ֹؿ�һ", ""));
        rankDataDic.list.Add(new RankData(0, 0, "ƴ�ֹؿ���", "Scene2"));
        rankDataDic.list.Add(new RankData(0, 0, "ƴ�ֹؿ���", "Scene3"));
        rankDataDic.list.Add(new RankData(0, 0, "����ؿ�һ", "Scene4"));
        rankDataDic.list.Add(new RankData(0, 0, "����ؿ���", "Scene5"));
        rankDataDic.list.Add(new RankData(0, 0, "����ؿ���", "Scene6"));
        //�������а����ݵ�������
        JsonMgr.Instance.SaveData(rankDataDic, "Rank");
        musicData = new MusicData
        {
            isOpenMusic = true,
            isOpenSound = true,
            musicValue = 1,
            soundValue = 1
        };
        JsonMgr.Instance.SaveData(musicData, "Music");
    }

    //�������ֿ���
    public void SetOpenMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        //���ĺ��������浽����
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //������Ч����
    public void SetOpenSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //���ĺ��������浽����
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //�������ִ�С
    public void SetMusicValue(float value)
    {
        musicData.musicValue = value;
        //���ĺ��������浽����
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //������Ч��С
    public void SetSoundValue(float value)
    {
        musicData.soundValue = value;
        //���ĺ��������浽����
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //ͬ����������
    public void UpdateMusicData(AudioSource audioSource)
    {
        audioSource.mute = !musicData.isOpenMusic;
        audioSource.volume = musicData.musicValue;
    }
    //ͬ����Ч����
    public void UpdateSoundData(AudioSource audioSource)
    {
        audioSource.mute = !musicData.isOpenSound;
        audioSource.volume = musicData.soundValue;
    }
    /// <summary>
    /// ������������Ҳ���һ����Ч
    /// </summary>
    /// <param name="musicName"></param>
    public void AutoSoundPlay(string musicName)
    {
        //�Ƿ񲥷���Ч
        bool isPlaySound = false;
        for(int i=0;i<audioSourcesList.Count;i++)
        {
           if(!audioSourcesList[i].isPlaying&&!isPlaySound)
            {
                audioSourcesList[i].clip = Resources.Load<AudioClip>("Music/" + musicName);
                UpdateSoundData(audioSourcesList[i]);
                audioSourcesList[i].Play();
                isPlaySound = true;
            }
        }
        if (!isPlaySound)
        {
            //��̬�����Ч
            AudioSource sourceAudioSource = gameObject.AddComponent<AudioSource>();
            sourceAudioSource.clip = Resources.Load<AudioClip>(musicName);
            UpdateSoundData(sourceAudioSource);
            audioSourcesList.Add(sourceAudioSource);
        }
    }
    /// <summary>
    /// ɾ��������Ч��audiosouce
    /// </summary>
    public void DeleteAourceAudioSource()
    {
        for (int i = 0; i < audioSourcesList.Count; i++)
        {
            Destroy(audioSourcesList[i]);
        }
        audioSourcesList = null;
    }
}
