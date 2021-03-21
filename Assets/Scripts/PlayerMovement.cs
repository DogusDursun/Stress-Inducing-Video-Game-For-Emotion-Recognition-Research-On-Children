using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private Rigidbody2D myBody;
    public bool is_dead = false;
    public bool height_passed = false;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject collector_found = GameObject.Find("Collector");
        Collector collector_script = collector_found.GetComponent<Collector>();
        Score score_script = gameObject.GetComponent<Score>();
        is_dead = collector_script.is_it_dead || score_script.is_itdead;
        if (!is_dead)
        {
            Vector2 vel = myBody.velocity;
            vel.x = Input.GetAxis("Horizontal") * speed;
            myBody.velocity = vel;
        } else
        {
            Vector2 vel = myBody.velocity;
            vel.x = Input.GetAxis("Horizontal") * 0f;
            myBody.velocity = vel;
            if (!height_passed)
            {
                if (transform.position.y >= -0.5f) {
                    height_passed = true;
                }
                transform.position += Vector3.up * 0.25f * speed * Time.deltaTime;
            } else if (height_passed)
            {
                transform.position += Vector3.down * 0.5f * speed * Time.deltaTime;
            }
        }
    }

    /*
      if (Input.GetKey(KeyCode.LeftArrow))
      {
          transform.position += Vector3.left * speed * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
          transform.position += Vector3.right * speed * Time.deltaTime;
      }*/
}
