using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LogTaker : MonoBehaviour
{
    string file_name = "";
    private void Start()
    {
        string directory_check = System.Environment.GetFolderPath(               // Delete game folder if the game opened for another time
               System.Environment.SpecialFolder.Desktop) + "/GAME_FOLDER";
        if (Directory.Exists(directory_check))
        {
            Directory.Delete(directory_check, true);
        }
        DontDestroyOnLoad(this);
    }
    void OnEnable() 
    { 
        Application.logMessageReceived += Log; 
    }
    void OnDisable() 
    { 
        Application.logMessageReceived -= Log; 
    }
    public void Log(string logString, string stackTrace, LogType type)
    {
        if (file_name == "")
        {
            string directory = System.Environment.GetFolderPath(
               System.Environment.SpecialFolder.Desktop) + "/GAME_FOLDER/LOGS";
            System.IO.Directory.CreateDirectory(directory);
            file_name = directory + "/logs.txt";
        }
        try { System.IO.File.AppendAllText(file_name, logString + "\n"); }
        catch { }
    }
}
