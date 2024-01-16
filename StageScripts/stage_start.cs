using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{
    private bool is_player_called = false;
    private GameObject playerObject;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;

    // �X�e�[�W�J�n�n�_�̒S���X�e�[�W��
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
        // �v���C���[���Ăяo�������݂̃X�e�[�W�����S���X�e�[�W���Ɠ����ł����
        if (is_player_called == false && unique_stage_number == stageNumberManager.GetStageNumber())
        {
            is_player_called = true;
            playerObject.transform.position = transform.position;
        }
    }
}
