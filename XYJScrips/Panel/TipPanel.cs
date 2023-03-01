using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TipPanel : BasePanel
{
    //取消按钮
    public Button canselButton;
    //确定按钮
    public Button sureButton;
    //提示文字
    public Text tipText;
    //点击是或者否
    private bool isSure;
    //点击确认按钮的时候执行的函数
    private UnityAction sureAction;
    //点击确认取消的时候执行的函数
    private UnityAction canselAction;
    protected override void Init()
    {
        canselButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            canselAction?.Invoke();
            canselAction = null;
        });
        sureButton.onClick.AddListener(() =>
        {
            //同步音效数据
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //播放点击音效
            clickAudioSource.Play();
            sureAction?.Invoke();
            sureAction = null;
        });
    }
    //改变提示内容
    public void ChangeTipInfo(string info)
    {
        tipText.text = info;
    }
    //传函数给委托，点击确定按钮时执行
    public void SureClick(UnityAction unityAction)
    {
            sureAction += unityAction;
    }
    //传函数给委托，点击取消按钮时执行
    public void CanselClick(UnityAction unityAction)
    {
        canselAction += unityAction;
    }
}
