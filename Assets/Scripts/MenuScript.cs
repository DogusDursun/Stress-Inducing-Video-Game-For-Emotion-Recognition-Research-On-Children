using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private string playername;
    private string extra_info;
    private string player_by; //birth year
    private string player_bm; //birth month
    private string player_bd; //birth day
    private string player_gender;
    public AudioSource Click;
    // Start is called before the first frame update

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", A2, " + System.DateTime.Now.TimeOfDay);
        Application.Quit();
    }
    public void SetFullscreen (bool is_fs)
    {
        /*GameObject data_to_save = GameObject.Find("PlayerDataSaver");                     //Check if player data is taken correctly
        PlayerData player_data_script = data_to_save.GetComponent<PlayerData>();
        Debug.Log(player_data_script.player_name);
        Debug.Log(player_data_script.extra_information);
        Debug.Log(player_data_script.age);
        Debug.Log(player_data_script.gender);*/

        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", B, " + System.DateTime.Now.TimeOfDay);
        Screen.fullScreen = is_fs;
    }
    public void PrintToLog ()
    {
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", " + button_name + ", " + System.DateTime.Now.TimeOfDay);

    }
    public void NextEmoji ()
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", "  + p_d_s.gender + ", " + p_d_s.extra_information + ", F3, " + System.DateTime.Now.TimeOfDay);
    }
    public void SavePlayerData ()
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData player_data_script = data_to_save.GetComponent<PlayerData>();

        playername = GameObject.Find("PlayerName").GetComponent<TMP_InputField>().text;
        playername = playername.Replace(",", "");
        if (playername == "")
        {
            playername = "-";
        }
        player_data_script.player_name = playername;

        extra_info = GameObject.Find("SpecialCondition").GetComponent<TMP_InputField>().text;
        extra_info = extra_info.Replace(",", "");
        if (extra_info == "")
        {
            extra_info = "-";
        }
        player_data_script.extra_information = extra_info;

        TMP_Dropdown Age_BD = GameObject.Find("BDay").GetComponent<TMP_Dropdown>();
        player_bd = Age_BD.options[Age_BD.value].text;
        if (player_bd != "Gün")
        {
            player_data_script.b_day = player_bd;
        }

        TMP_Dropdown Age_BM = GameObject.Find("BMonth").GetComponent<TMP_Dropdown>();
        player_bm = Age_BM.options[Age_BM.value].text;
        if (player_bm != "Ay")
        {
            player_data_script.b_month = player_bm;
        }

        TMP_Dropdown Age_BY = GameObject.Find("BYear").GetComponent<TMP_Dropdown>();
        player_by = Age_BY.options[Age_BY.value].text;
        if (player_by != "Yıl")
        {
            player_data_script.b_year = player_by;
        }

        player_data_script.age_found();
        
        TMP_Dropdown Gender_Dd = GameObject.Find("Gender").GetComponent<TMP_Dropdown>();
        player_gender = Gender_Dd.options[Gender_Dd.value].text;
        if (player_gender != "Cinsiyet")
        {
            player_data_script.gender = player_gender;
        }

        Debug.Log(player_data_script.player_name + ", " + player_data_script.age + ", " + player_data_script.gender + ", " + player_data_script.extra_information + ", A1, " + System.DateTime.Now); //Start game after taking player data
    }

    public void PlayClick()
    {
        Click.Play();
    }
}
