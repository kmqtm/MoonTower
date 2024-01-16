using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_sound : MonoBehaviour
{
    public AudioClip down_stage_sound;
    public AudioClip middle_stage_sound;
    public AudioClip up_stage_sound;
    public float loweredVolume = 0.5f;  // 下げたい音量の割合（0.0 ～ 1.0）

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
        // 5つのステージごとに音楽を変える
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
        // 音楽が再生中かどうかを確認
        if (audio_source.isPlaying)
        {
            // 対象外の音声が再生中
            if (audio_source.clip != audioClip)
            {
                // 再生停止
                audio_source.Stop();

                // 対象の音声を再生開始
                audio_source.clip = audioClip;
                audio_source.volume = loweredVolume; // 音量を下げる
                audio_source.Play();
            }
        }
        else
        {
            // 対象の音声を再生開始
            audio_source.clip = audioClip;
            audio_source.volume = loweredVolume; // 音量を下げる
            audio_source.Play();
        }
    }
}
