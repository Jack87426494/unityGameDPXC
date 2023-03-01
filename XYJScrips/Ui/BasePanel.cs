using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //�����������ʱ���õ�ί��
   private UnityAction HideAction;

    //�Ƿ�����
   private bool isOpen;
    
    //���뵭�����ٶ�
    private float fadeSpeed=4f;
    private CanvasGroup canvasGroup;

    //�����ť����Դ
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
        //������Ϸui��Ч
        SetSound();
        //ע�����������¼��ķ���
        Init();
    }
    //ע�����������¼��ķ���
    protected abstract void Init();
    //��ʾ�̳е��������
    public virtual void ShowSelf()
    { 
        canvasGroup.alpha = 0f;
        isOpen = true;
    }
    //���ؼ̳е��������
    public virtual void HideSelf(UnityAction action)
    {
        canvasGroup.alpha = 1f;
        isOpen = false;
        //����ָ���ʱ��Ҫִ�еĺ�������ί��
        HideAction += action;
    }
    //���õ����Ч
    public virtual void SetSound()
    {
        clickAudioSource = GetComponent<AudioSource>();
        //�������ű�����������Դ�ű���δ��������Դ��panelҲ������д�ú���
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
                //������ִ�еĺ�����ɾ�����壩
                HideAction?.Invoke();
                HideAction = null;
            }
        }
    }
}
