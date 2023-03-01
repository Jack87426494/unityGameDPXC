using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuidePanel : BasePanel
{
    //���ذ�ť
    public Button backButton;
  
    protected override void Init()
    {
        backButton.onClick.AddListener(() =>
        {
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            clickAudioSource.Play();
            //�رղ���ָ�����
            UiManager.Instance.HidePanel<GuidePanel>();
            //����Ϸ�����
            UiManager.Instance.ShowPanel<MainPanel>();
        });
    }
}
