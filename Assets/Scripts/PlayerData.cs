using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string player_name = "-";
    public string gender = "-";
    public string b_year = "-";
    public string b_month = "-";
    public string b_day = "-";
    public string extra_information = "-";
    public string age = "-";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void age_found ()
    {
        age = b_day + "/" + b_month + "/" + b_year;
    }
}
