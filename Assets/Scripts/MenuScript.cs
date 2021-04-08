using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        Debug.Log(System.DateTime.Now);
        Debug.Log("APPLICATION CLOSED");
        Application.Quit();
    }

    public void SetFullscreen (bool is_fs)
    {
        Debug.Log(System.DateTime.Now);
        Debug.Log("Fullscreen value changed.");
        Screen.fullScreen = is_fs;
    }
}
