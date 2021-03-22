using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float up_speed = 2f;
    public float down_speed = -3f;
    public float ceiling = 3.66f;
    public float ground = -4.62f;
    private Rigidbody2D myBalloon;
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
}
