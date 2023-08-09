using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
#if UNITY_EDITOR
        Application.targetFrameRate = 60;
#endif
    }
   
}
