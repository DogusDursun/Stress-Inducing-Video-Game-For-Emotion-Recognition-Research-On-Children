using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public bool is_dead = false;
    public bool height_passed = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.position.x > -0.9f)
                {
                    transform.Translate(-1.0f, 0.0f, 0.0f);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.position.x < 0.9f)
                {
                    transform.Translate(1.0f, 0.0f, 0.0f);
                }
            }
        } else
        {
            if (!height_passed)
            {
                if (transform.position.y >= -0.5f)
                {
                    height_passed = true;
                }
                transform.position += Vector3.up * 0.5f * Time.deltaTime;
            }
            else if (height_passed)
            {
                transform.position += Vector3.down * 1f * Time.deltaTime;
            }
        }
    }
}
