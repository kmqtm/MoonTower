using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stage_number_display : MonoBehaviour
{
    private string stage_number_display_text_main   = "STAGE  ";
    private string stage_number_display_text_sub    = "";
    private int stage_number                        = 0;

    private TextMeshProUGUI stage_number_display_tmpro;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;

    // Start is called before the first frame update
    void Start()
    {
        stage_number_display_tmpro  = GetComponent<TextMeshProUGUI>();
        stageManager                = GameObject.Find("StageManager");
        stageNumberManager          = stageManager.GetComponent<StageNumberManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stage_number = stageNumberManager.GetStageNumber();

        // 現在のステージ数が二桁以下であれば
        if (stage_number < 10)
        {
            stage_number_display_text_sub = "[0" + stage_number + "/15]";
        }
        else
        {
            stage_number_display_text_sub = "[" + stage_number + "/15]";
        }

        // ステージ数テキストの書き換え
        stage_number_display_tmpro.text = stage_number_display_text_main + stage_number_display_text_sub;
    }
}
