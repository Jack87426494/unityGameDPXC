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

    //排行榜数据
    public RankDataList rankDataDic;
    //音乐数据
    public MusicData musicData;
    //音效audiosouce 的list
    private List<AudioSource> audioSourcesList = new List<AudioSource>();
    private void Awake()
    {
        ////把这个注释关了运行一次游戏数据格式化了
        //ReplaceData();
        //DontDestroyOnLoad(this.gameObject);
        instance = this;
        //游戏一开始就从磁盘上读取排行榜数据
        rankDataDic = JsonMgr.Instance.LoadData<RankDataList>("Rank");
        //如果排行榜还没有数据
        if(rankDataDic==null)
        {
            rankDataDic = new RankDataList();
            rankDataDic.list.Add(new RankData( 0, 0, "拼字关卡一", ""));
            rankDataDic.list.Add(new RankData(0, 0, "拼字关卡二", "Scene2"));
            rankDataDic.list.Add(new RankData(0, 0, "拼字关卡三", "Scene3"));
            rankDataDic.list.Add(new RankData(0, 0, "成语关卡一", "Scene4"));
            rankDataDic.list.Add(new RankData(0, 0, "成语关卡二", "Scene5"));
            rankDataDic.list.Add(new RankData(0, 0, "成语关卡三", "Scene6"));
            //储存排行榜数据到磁盘上
            JsonMgr.Instance.SaveData(rankDataDic, "Rank");
        }
        //游戏一开始就从磁盘上读取音乐数据
        musicData = JsonMgr.Instance.LoadData<MusicData>("Music");
        //如果音乐数据还没有保存过
        if(musicData==null)
        {
            musicData = new MusicData
            {
                isOpenMusic = true,
                isOpenSound = true,
                musicValue = 1,
                soundValue = 1
            };
            //更改后立即保存到磁盘
            JsonMgr.Instance.SaveData(musicData, "Music");
        }
    }
    /// <summary>
    /// 添加排行榜数据
    /// </summary>
    /// <param name="cheakPoint">关卡序号</param>
    /// <param name="score">玩家在本关卡获得的分数</param>
    /// <param name="time">玩家在本关卡进行的时间</param>
    /// <param name="cheakPointName">在游戏选关面板上显示的关卡名字</param>
    /// <param name="reallySceneName">实际的游戏场景对应的名字</param>
    public void AddRankData(int cheakPoint,int score,int time,string cheakPointName,string reallySceneName)
    {
        //如果保存的关卡数据，之前已经保存过来数据，比较新数据的分数和原来的分数大小，保留分数更大的那个
        if (rankDataDic.list.Count>cheakPoint)
        {
            if (rankDataDic.list[cheakPoint].score < score)
            {
                rankDataDic.list[cheakPoint] = new RankData(score, time,cheakPointName,reallySceneName);
            }
        }
        //否则直接保存一条关卡记录数据
        else
        {
            rankDataDic.list.Add(new RankData(score, time,cheakPointName,reallySceneName));
        }
        //储存排行榜数据到磁盘上
        JsonMgr.Instance.SaveData(rankDataDic,"Rank");
    }
    /// <summary>
    /// 同步一条排行榜的数据
    /// </summary>
    /// <param name="cheakPoint">关卡序号</param>
    /// <param name="rankData">此关卡需要同步的所有数据</param>
    public void UpDataRankData(int cheakPoint,RankData rankData)
    {
        //如果数据库里面有这个数据
        if (rankDataDic.list[cheakPoint] != null)
        {
            rankData.cheakPointName = rankDataDic.list[cheakPoint].cheakPointName;
            rankData.reallySceneName = rankDataDic.list[cheakPoint].reallySceneName;
            rankData.score = rankDataDic.list[cheakPoint].score;
            rankData.time = rankDataDic.list[cheakPoint].time;
        }
        else
        {
            rankData.cheakPointName ="未解锁关卡";
            rankData.reallySceneName = "";
            rankData.score =0;
            rankData.time = 0;
        }
    }
/// <summary>
/// 格式化储存数据
/// </summary>
    public void ReplaceData()
    {
        rankDataDic = new RankDataList();
        rankDataDic.list.Add(new RankData(0, 0, "拼字关卡一", ""));
        rankDataDic.list.Add(new RankData(0, 0, "拼字关卡二", "Scene2"));
        rankDataDic.list.Add(new RankData(0, 0, "拼字关卡三", "Scene3"));
        rankDataDic.list.Add(new RankData(0, 0, "成语关卡一", "Scene4"));
        rankDataDic.list.Add(new RankData(0, 0, "成语关卡二", "Scene5"));
        rankDataDic.list.Add(new RankData(0, 0, "成语关卡三", "Scene6"));
        //储存排行榜数据到磁盘上
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

    //控制音乐开关
    public void SetOpenMusic(bool isOpen)
    {
        musicData.isOpenMusic = isOpen;
        //更改后立即保存到磁盘
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //控制音效开关
    public void SetOpenSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //更改后立即保存到磁盘
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //控制音乐大小
    public void SetMusicValue(float value)
    {
        musicData.musicValue = value;
        //更改后立即保存到磁盘
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //控制音效大小
    public void SetSoundValue(float value)
    {
        musicData.soundValue = value;
        //更改后立即保存到磁盘
        JsonMgr.Instance.SaveData(musicData, "Music");
    }
    //同步音乐数据
    public void UpdateMusicData(AudioSource audioSource)
    {
        audioSource.mute = !musicData.isOpenMusic;
        audioSource.volume = musicData.musicValue;
    }
    //同步音效数据
    public void UpdateSoundData(AudioSource audioSource)
    {
        audioSource.mute = !musicData.isOpenSound;
        audioSource.volume = musicData.soundValue;
    }
    /// <summary>
    /// 添加音乐器并且播放一次音效
    /// </summary>
    /// <param name="musicName"></param>
    public void AutoSoundPlay(string musicName)
    {
        //是否播放音效
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
            //动态添加音效
            AudioSource sourceAudioSource = gameObject.AddComponent<AudioSource>();
            sourceAudioSource.clip = Resources.Load<AudioClip>(musicName);
            UpdateSoundData(sourceAudioSource);
            audioSourcesList.Add(sourceAudioSource);
        }
    }
    /// <summary>
    /// 删除所有音效的audiosouce
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
