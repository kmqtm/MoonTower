using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 設定の読み込み
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSettings()
    {
        QualitySettings.vSyncCount = 0;
        // FPSを60に固定
        Application.targetFrameRate = 60;
    }
}
