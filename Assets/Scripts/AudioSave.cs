using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSave : MonoBehaviour
{
    public bool mute = false;
        // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void MuteSound(bool is_muted)
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", T, " + System.DateTime.Now.TimeOfDay);
        mute = is_muted;
    }
}

