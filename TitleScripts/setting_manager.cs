using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �ݒ�̓ǂݍ���
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSettings()
    {
        QualitySettings.vSyncCount = 0;
        // FPS��60�ɌŒ�
        Application.targetFrameRate = 60;
    }
}
