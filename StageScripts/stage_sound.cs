using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_sound : MonoBehaviour
{
    public AudioClip down_stage_sound;
    public AudioClip middle_stage_sound;
    public AudioClip up_stage_sound;
    public float loweredVolume = 0.5f;  // �����������ʂ̊����i0.0 �` 1.0�j

    private AudioSource audio_source;
    private StageNumberManager stageNumberManager;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        stageNumberManager = GetComponent<StageNumberManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 5�̃X�e�[�W���Ƃɉ��y��ς���
        if (stageNumberManager.stage_number <= 5)
        {
            PlayerSound(down_stage_sound);
        }
        else if (stageNumberManager.stage_number <= 10)
        {
            PlayerSound(middle_stage_sound);
        }
        else if (stageNumberManager.stage_number <= 15)
        {
            PlayerSound(up_stage_sound);
        }
    }

    private void PlayerSound(AudioClip audioClip)
    {
        // ���y���Đ������ǂ������m�F
        if (audio_source.isPlaying)
        {
            // �ΏۊO�̉������Đ���
            if (audio_source.clip != audioClip)
            {
                // �Đ���~
                audio_source.Stop();

                // �Ώۂ̉������Đ��J�n
                audio_source.clip = audioClip;
                audio_source.volume = loweredVolume; // ���ʂ�������
                audio_source.Play();
            }
        }
        else
        {
            // �Ώۂ̉������Đ��J�n
            audio_source.clip = audioClip;
            audio_source.volume = loweredVolume; // ���ʂ�������
            audio_source.Play();
        }
    }
}
