using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    static WebCamTexture my_camera;
    public RawImage display;
    private int photo_no = 0;
    string file_name = "";
    void Start()
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", F1, " + System.DateTime.Now.TimeOfDay); // Camera session began

        if (WebCamTexture.devices.Length < 1) 
        {
            Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", F4, " + System.DateTime.Now.TimeOfDay); // No attached camera
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            if (my_camera == null)
            {
                my_camera = new WebCamTexture();
                my_camera.requestedWidth = 352;
                my_camera.requestedHeight = 288;
            }

            //GetComponent<Renderer>().material.mainTexture = my_camera;

            display.texture = my_camera;

            if (!my_camera.isPlaying)
            {
                my_camera.Play();
            }

            InvokeRepeating("TakeFrame", 2f, 1f);
        }
   
    }
    void TakeFrame()  
    {
       // yield return new WaitForEndOfFrame();
        if (file_name == "")
        {
            string directory = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop) + "/GAME_FOLDER/FRAMES";
            System.IO.Directory.CreateDirectory(directory);
            file_name = directory;
        }

        Texture2D photo = new Texture2D(my_camera.width, my_camera.height);
        photo.SetPixels(my_camera.GetPixels());
        photo.Apply();

        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(file_name + "/" + photo_no.ToString() + ".png", bytes);
        photo_no++;
    }
   
    public void stop_cam()
    {
        GameObject data_to_save = GameObject.Find("PlayerDataSaver");
        PlayerData p_d_s = data_to_save.GetComponent<PlayerData>();
        Debug.Log(p_d_s.player_name + ", " + p_d_s.age + ", " + p_d_s.gender + ", " + p_d_s.extra_information + ", F2, " + System.DateTime.Now.TimeOfDay); // Camera session ended
        if (my_camera != null)
        {
            display.texture = null;
            my_camera.Stop();
            my_camera = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
