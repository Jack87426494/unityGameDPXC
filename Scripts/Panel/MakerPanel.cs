using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerPanel : BasePanel
{
    //返回按钮
    public Button backButton;

    protected override void Init()
    {
        backButton.onClick.AddListener(() =>
        {
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //关闭操作指南面板
            UiManager.Instance.HidePanel<MakerPanel>();
            //打开游戏主面板
            UiManager.Instance.ShowPanel<MainPanel>();
        });
    }
}
