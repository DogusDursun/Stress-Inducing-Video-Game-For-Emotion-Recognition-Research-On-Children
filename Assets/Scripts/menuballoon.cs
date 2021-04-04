using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menuballoon : MonoBehaviour
{
    public float up_speed = 80f;
    public float down_speed = -100f;
    private Rigidbody2D myBalloon;
    private int is_up = -1;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        myBalloon = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject spacebutton = GameObject.Find("Button");
        if (transform.position.y > 245f || transform.position.y < 70f)
        {
            if (transform.position.y < 70f)
            {
                spacebutton.transform.position = new Vector2(575f, 100f);
            }
            else if (transform.position.y > 245f)
            {
                spacebutton.transform.position = new Vector2(0, 1000f);
            }
            animator.SetInteger("balcolor", 1);
        }
        else
        {
            animator.SetInteger("balcolor", 3);
        }
        if (transform.position.y < 50f)
        {
            is_up = 1;
        } else if (transform.position.y > 265f)
        {
            is_up = -1;
        }
        Vector2 vel = myBalloon.velocity;
        if (is_up == 1)
        {
            animator.SetBool("ifPushed", true);
            vel.y = up_speed;
            myBalloon.velocity = vel;
        }
        else
        {
            animator.SetBool("ifPushed", false);
            vel.y = down_speed;
            myBalloon.velocity = vel;
        }
    }
}
