/* 
 * �Q�l����
 * [1] URL: https://www.subarunari.com/entry/2017/06/30/163120
 * �擾�� 2023-12-27
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGoal : MonoBehaviour
{
    private BoxCollider2D stage_goal_box_collider_2d;
    private GameObject stageManager;
    private StageNumberManager stageNumberManager;
    private GameObject cutIn;
    private CutInMove cutInMove;

    // Start is called before the first frame update
    private void Start()
    {
        stage_goal_box_collider_2d = GetComponent<BoxCollider2D>();

        stageManager        = GameObject.Find("StageManager");
        stageNumberManager  = stageManager.GetComponent<StageNumberManager>();

        cutIn               = GameObject.Find("CutIn");
        cutInMove           = cutIn.GetComponent<CutInMove>();
    }

    // �Q�l[1]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            // �X�e�[�W�����X�V
            stageNumberManager.IncrementStageNumber();
            // �J�b�g�C�����o
            cutInMove.DoCutIn();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }
}
