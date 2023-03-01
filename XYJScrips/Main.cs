using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏开始入口
public class Main : MonoBehaviour
{
    private void Awake()
    {
        //显示主UI界面和背景图
        UiManager.Instance.ShowPanel<BkPanel>();
        UiManager.Instance.ShowPanel<MainPanel>();
        //生成背景音乐管理器,和数据管理器
        MusicManager.Instance.Open();
    }
}
