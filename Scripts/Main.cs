using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ��ʼ���
public class Main : MonoBehaviour
{
    private void Awake()
    {
        //��ʾ��UI����ͱ���ͼ
        UiManager.Instance.ShowPanel<BkPanel>();
        UiManager.Instance.ShowPanel<MainPanel>();
        //���ɱ������ֹ�����,�����ݹ�����
        MusicManager.Instance.Open();
    }
}
