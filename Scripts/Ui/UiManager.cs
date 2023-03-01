using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager 
{
    private static UiManager instance=new UiManager();
    public static UiManager Instance => instance;
    //canvas��λ��
    private Transform canvasTransform;
    private GameObject gameCamera;
    //��ʾ������Ŀǰ���ڵ����
    private Dictionary<string, BasePanel> dicPanel = new Dictionary<string, BasePanel>();
    private UiManager()
    {
        gameCamera = GameObject.Find("GameCamera");
        canvasTransform = GameObject.Find("Canvas").transform;
        //������ʱ���Ƴ�Canvas���
        GameObject.DontDestroyOnLoad(canvasTransform.gameObject);
    }
    //��ʾ���
    public T ShowPanel<T>(bool isFade=true) where T:BasePanel
    {
        //�õ���Ҫ��ʾ�������֣�������غ����ͬ���Ľű�
        string panelName = typeof(T).Name;
        //����������Ѿ���������Ҫ��ȡ������������������һ������ֹ�������ظ������
        if (dicPanel.ContainsKey(panelName))
            return dicPanel[panelName]as T;
        //Resources�м��ز����ڳ�����ʵ������������
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UiPanel/" + panelName));
        //���ú�����λ��
        panelObj.transform.SetParent(canvasTransform, false);
        //�õ�������ϵĽű���������
        T panel = panelObj.GetComponent<T>();
        if (isFade)
        {
            //������������
            panel.ShowSelf();
        }
        //������������ֵ��¼
        dicPanel.Add(panelName,panel);
        return panel;
    }
    //�������
    public void HidePanel<T>(bool isFade=true)where T:BasePanel//isFade�ж�Ҫ��Ҫ���뵭��,Ĭ��Ҫ����
    {
        //�õ���Ҫ�����������֣�������غ����ͬ���Ľű�
        string panelName = typeof(T).Name;
        if (dicPanel.ContainsKey(panelName))
        {
            //��֤����ȫ����֮����ɾ������
            if (isFade)
            {
                dicPanel[panelName].HideSelf(()=> 
                {
                    //������ɾ�����
                    GameObject.Destroy(dicPanel[panelName].gameObject);
                    //���ֵ���ɾ�����
                    dicPanel.Remove(panelName);
                });
            }
            else
            {
                //������ɾ�����
                GameObject.Destroy(dicPanel[panelName].gameObject);
                //���ֵ���ɾ�����
                dicPanel.Remove(panelName);
            }
        }
    }
    //�õ����ű�
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (dicPanel.ContainsKey(panelName))
        {
            return dicPanel[panelName]as T;
        }
        else
        {
            //���û�����ֵ����ҵ��ű�����ֱ����Resources�м���һ������
            GameObject panel = Resources.Load<GameObject>("UiPanel/" + panelName);
            return panel.GetComponent<T>();
        }
    }
 
}
