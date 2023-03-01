using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //控制隐藏面板时调用的委托
   private UnityAction HideAction;

    //是否打开面板
   private bool isOpen;
    
    //淡入淡出的速度
    private float fadeSpeed=4f;
    private CanvasGroup canvasGroup;

    //点击按钮声音源
    protected AudioSource clickAudioSource;

    protected  virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if(canvasGroup==null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    protected virtual void Start()
    {
        //设置游戏ui音效
        SetSound();
        //注册各个面板上事件的方法
        Init();
    }
    //注册各个面板上事件的方法
    protected abstract void Init();
    //显示继承的面板自身
    public virtual void ShowSelf()
    { 
        canvasGroup.alpha = 0f;
        isOpen = true;
    }
    //隐藏继承的面板自身
    public virtual void HideSelf(UnityAction action)
    {
        canvasGroup.alpha = 1f;
        isOpen = false;
        //隐藏指令触发时将要执行的函数加入委托
        HideAction += action;
    }
    //设置点击音效
    public virtual void SetSound()
    {
        clickAudioSource = GetComponent<AudioSource>();
        //如果子类脚本挂载了声音源脚本，未挂载声音源的panel也不用重写该函数
        if (clickAudioSource != null)
        {
            clickAudioSource.clip = Resources.Load<AudioClip>("Music/Click");
        }
    }
    protected virtual void Update()
    {
        if(isOpen&&canvasGroup.alpha<1)
        {
            canvasGroup.alpha += fadeSpeed * Time.deltaTime;
            if(canvasGroup.alpha>=1)
            {
                canvasGroup.alpha = 1;
            }
        }
       else if(!isOpen &&canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            if(canvasGroup.alpha<=0)
            {
                canvasGroup.alpha = 0;
                //显隐后执行的函数（删除物体）
                HideAction?.Invoke();
                HideAction = null;
            }
        }
    }
}
