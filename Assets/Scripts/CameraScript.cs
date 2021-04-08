using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    static WebCamTexture my_camera;
    public RawImage display;
    private int photo_no = 0;
    string file_name = "";
    void Start()
    {
        Debug.Log(System.DateTime.Now);
        Debug.Log("CAMERA SESSION BEGAN");

        if (my_camera == null)
        {
            my_camera = new WebCamTexture();
        }

        //GetComponent<Renderer>().material.mainTexture = my_camera;

        display.texture = my_camera;

        if (!my_camera.isPlaying)
        {
            my_camera.Play();
        }

        InvokeRepeating("TakeFrame", 2f, 1f);
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
        Debug.Log(System.DateTime.Now);
        Debug.Log("CAMERA SESSION ENDED");
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
