using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ê›íËÇÃì«Ç›çûÇ›
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSettings()
    {
        QualitySettings.vSyncCount = 0;
        // FPSÇ60Ç…å≈íË
        Application.targetFrameRate = 60;
    }
}
