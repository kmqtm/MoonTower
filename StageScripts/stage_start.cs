using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{
    private bool is_player_called = false;
    private GameObject playerObject;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;

    // ステージ開始地点の担当ステージ数
    public int unique_stage_number = 1;

    // Start is called before the first frame update
    private void Start()
    {
        playerObject = GameObject.Find("Player");
        stageManager = GameObject.Find("StageManager");
        stageNumberManager = stageManager.GetComponent<StageNumberManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        // プレイヤー未呼び出しかつ現在のステージ数が担当ステージ数と同じであれば
        if (is_player_called == false && unique_stage_number == stageNumberManager.GetStageNumber())
        {
            is_player_called = true;
            playerObject.transform.position = transform.position;
        }
    }
}
