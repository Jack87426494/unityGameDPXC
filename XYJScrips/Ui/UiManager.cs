using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager 
{
    private static UiManager instance=new UiManager();
    public static UiManager Instance => instance;
    //canvas的位置
    private Transform canvasTransform;
    private GameObject gameCamera;
    //表示场景中目前存在的面板
    private Dictionary<string, BasePanel> dicPanel = new Dictionary<string, BasePanel>();
    private UiManager()
    {
        gameCamera = GameObject.Find("GameCamera");
        canvasTransform = GameObject.Find("Canvas").transform;
        //过场景时不移除Canvas面板
        GameObject.DontDestroyOnLoad(canvasTransform.gameObject);
    }
    //显示面板
    public T ShowPanel<T>(bool isFade=true) where T:BasePanel
    {
        //得到需要显示面板的名字，必须挂载和面板同名的脚本
        string panelName = typeof(T).Name;
        //如果场景中已经存在所需要获取的面板的则，跳过加载这一步，防止有两个重复的面板
        if (dicPanel.ContainsKey(panelName))
            return dicPanel[panelName]as T;
        //Resources中加载并且在场景中实例化出面板对象
        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UiPanel/" + panelName));
        //设置好面板的位置
        panelObj.transform.SetParent(canvasTransform, false);
        //得到面板身上的脚本并返回它
        T panel = panelObj.GetComponent<T>();
        if (isFade)
        {
            //控制面板的显隐
            panel.ShowSelf();
        }
        //将面板加入面板字典记录
        dicPanel.Add(panelName,panel);
        return panel;
    }
    //隐藏面板
    public void HidePanel<T>(bool isFade=true)where T:BasePanel//isFade判断要不要淡入淡出,默认要显隐
    {
        //得到需要隐藏面板的名字，必须挂载和面板同名的脚本
        string panelName = typeof(T).Name;
        if (dicPanel.ContainsKey(panelName))
        {
            //保证在完全淡出之后再删除物体
            if (isFade)
            {
                dicPanel[panelName].HideSelf(()=> 
                {
                    //场景上删除面板
                    GameObject.Destroy(dicPanel[panelName].gameObject);
                    //在字典中删除面板
                    dicPanel.Remove(panelName);
                });
            }
            else
            {
                //场景上删除面板
                GameObject.Destroy(dicPanel[panelName].gameObject);
                //在字典中删除面板
                dicPanel.Remove(panelName);
            }
        }
    }
    //得到面板脚本
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (dicPanel.ContainsKey(panelName))
        {
            return dicPanel[panelName]as T;
        }
        else
        {
            //如果没有在字典中找到脚本，则直接在Resources中加载一个返回
            GameObject panel = Resources.Load<GameObject>("UiPanel/" + panelName);
            return panel.GetComponent<T>();
        }
    }
 
}
