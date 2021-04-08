using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour
{
    public float up_speed = 2.20f;
    public float down_speed = -2.75f;
    public float ceiling = 3.66f;
    public float ground = -4.62f;
    private Rigidbody2D myBalloon;
    public Animator animator;
    private float game_time = 60f;
    private float time_passed = 0f;
    public Slider time_bar;
    private bool stopper = false;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject time_slider = GameObject.Find("Slider");
        time_bar = time_slider.GetComponent<Slider>();
        myBalloon = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log(System.DateTime.Now);
        Debug.Log("RELAXATION PHASE BEGAN");
        time_bar.maxValue = game_time;
        time_bar.value = game_time;
    }

    // Update is called once per frame
    void Update()
    {
        time_passed += Time.deltaTime;
        if (!stopper)
        {
            time_bar.value = game_time - time_passed;
        }
        if ((time_passed >= game_time) && !stopper)
        {
            Debug.Log(System.DateTime.Now);
            Debug.Log("RELAXATION PHASE ENDED");
            stopper = true;
            StartCoroutine(RestartGame());
        }
        GameObject spacebutton = GameObject.Find("Button");
        if (transform.position.y > 3f || transform.position.y < -4f)
        {
            if (transform.position.y < -4f)
            {
                spacebutton.transform.position = new Vector2(4.8f, -2.5f);
            } else if (transform.position.y > 3f)
            {
                spacebutton.transform.position = new Vector2(0,500f);
            }
            animator.SetInteger("balcolor", 1);
        } else 
        {
            animator.SetInteger("balcolor", 3);
        }
        Vector2 vel = myBalloon.velocity;
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("ifPushed", true);
            if (transform.position.y < ceiling) {
                vel.y = up_speed;
                myBalloon.velocity = vel;
            } else
            {
                vel.y = 0f;
                myBalloon.velocity = vel;
            }
        } else
        {
            animator.SetBool("ifPushed", false);
            if (transform.position.y > ground)
            {
                vel.y = down_speed;
                myBalloon.velocity = vel;
            }
            else
            {
                vel.y = 0f;
                myBalloon.velocity = vel;
            }
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
