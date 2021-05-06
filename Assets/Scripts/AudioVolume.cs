using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    public bool mute_value = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject audio_mute = GameObject.Find("AudioSaver");
        AudioSave audio_saved = audio_mute.GetComponent<AudioSave>();
        mute_value = audio_saved.mute;
        if (mute_value)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }  
    }
}
