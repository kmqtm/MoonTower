using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutInMove : MonoBehaviour
{
    public float cut_in_sprite_first_position  = -22.0f;
    public float cut_in_sprite_transform_speed  = 0.1f;
    private bool is_cut_in_activated = false;

    // �J�b�g�C���p�X�v���C�g�������ʒu�ɒu��
    private void PutCutInSpriteFirstPosition()
    {
        // �v���C���[�I�u�W�F�N�g���猩���ʒu(local position)�𗘗p���Ă���
        transform.localPosition = new Vector3(cut_in_sprite_first_position, cut_in_sprite_first_position, -2.0f);
    }

    // �J�b�g�C�����o
    public void DoCutIn()
    {
        is_cut_in_activated     = true;
        PutCutInSpriteFirstPosition();
    }

    // Start is called before the first frame update
    void Start()
    {
        PutCutInSpriteFirstPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (is_cut_in_activated == true)
        {
            transform.localPosition += new Vector3(cut_in_sprite_transform_speed, cut_in_sprite_transform_speed, 0.0f);
        }
        else
        {
            PutCutInSpriteFirstPosition();
        }

        if (transform.localPosition.x >= 100.0f)
        {
            is_cut_in_activated = false;
        }
    }
}
