using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSound : MonoBehaviour
{
    public AudioClip title_key_input_sound;

    private AudioSource audio_source;
    
    // Start is called before the first frame update
    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
        audio_source.clip = title_key_input_sound;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void PlayTitleKeyInputSound()
    {
        audio_source.Play();
    }
}
