using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip damaged_sound;
    public AudioClip ceiling_hit_sound;

    private AudioSource audio_source;

    void Start()
    {
        // AudioSource�R���|�[�l���g�̎擾
        audio_source = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void DamagedSoundPlay()
    {
        audio_source.clip = damaged_sound;
        PlaySound();
    }

    public void CeilingHitSoundPlay()
    {
        audio_source.clip = ceiling_hit_sound;
        audio_source.volume = 0.1f;
        PlaySound();
    }

    void PlaySound()
    {
        // AudioSource���g���ĉ����Đ�
        audio_source.Play();
    }
}
