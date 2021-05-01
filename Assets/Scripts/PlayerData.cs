using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string player_name = "-";
    public string gender = "-";
    public string age = "-";
    public string extra_information = "-";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
