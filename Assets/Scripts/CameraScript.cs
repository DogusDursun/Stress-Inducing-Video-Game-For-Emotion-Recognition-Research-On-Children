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
    void Start()
    {
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

        Texture2D photo = new Texture2D(my_camera.width, my_camera.height);
        photo.SetPixels(my_camera.GetPixels());
        photo.Apply();

        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + photo_no.ToString() + ".png", bytes);
        photo_no++;
    }
   
    public void stop_cam()
    {
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
