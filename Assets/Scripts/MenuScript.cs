using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        Debug.Log(System.DateTime.Now.TimeOfDay);
        Debug.Log("A2");
        Application.Quit();
    }
    public void SetFullscreen (bool is_fs)
    {
        Debug.Log(System.DateTime.Now.TimeOfDay);
        Debug.Log("B");
        Screen.fullScreen = is_fs;
    }
    public void PrintToLog ()
    {
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(System.DateTime.Now.TimeOfDay);
        Debug.Log(button_name);
    }
    public void NextEmoji()
    {
        Debug.Log(System.DateTime.Now.TimeOfDay);
        Debug.Log("F3");
    }
}
