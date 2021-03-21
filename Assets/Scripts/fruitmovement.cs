using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitmovement : MonoBehaviour
{
   // public GameObject holder;
    public Animator animator;
    public float fruit_speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject fruit__speed = GameObject.Find("fruitspeedholder");
        fruitspeed f_speed = fruit__speed.GetComponent<fruitspeed>();
        fruit_speed = f_speed.fruit_start_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "destroy")
        {
            transform.position += Vector3.down * fruit_speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (gameObject.tag == "bomb")
        {
            if (target.tag == "player")
            {
                animator.SetBool("isFail", true);
            } else if (target.tag == "collector")
            {
                animator.SetBool("isPoints", true);
            }
        }

        if (gameObject.tag == "point")
        {
            if (target.tag == "player")
            {
                animator.SetBool("isPoints", true);
            }
            else if (target.tag == "collector")
            {
                animator.SetBool("isFail", true);
            }
        }
    }
}
