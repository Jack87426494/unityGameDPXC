using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankContent : MonoBehaviour
{
    public Text rankText;

    public void setInfo(string cheakPointName,int time,int score)
    {
        rankText.text = cheakPointName + " " + "ʱ�䣺" + time+" "+ "������" + score;
    }
}
