using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDontDes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
