using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    public int drop_counter = 0;
    string obj_string = "";
    public bool is_it_dead = false;
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "bomb") {
            //target.gameObject.SetActive(false);
            target.tag = "destroy";
            StartCoroutine(RemoveAfterSeconds(0.4f, target.gameObject));
        } else if (target.tag == "point") {
            target.tag = "destroy";
            if (drop_counter < 10)
            {
                obj_string = "Sprite-0003 (" + drop_counter + ")";
                GameObject delete_heart = GameObject.Find(obj_string);
                delete_heart.SetActive(false);
            }
            drop_counter++;
            if (drop_counter == 10)
            {
                GameObject puhlayer = GameObject.Find("pepper");
               // puhlayer.transform.position = new Vector2(0, 100);
                // target.gameObject.SetActive(false);
                StartCoroutine(RemoveAfterSeconds(0.5f, target.gameObject));
                StartCoroutine(RestartGame());
            }
            else
            {
                StartCoroutine(RemoveAfterSeconds(0.5f, target.gameObject));
                //target.gameObject.SetActive(false);
                GameObject fruit__speed2 = GameObject.Find("fruitspeedholder");
                fruitspeed fruit_move = fruit__speed2.GetComponent<fruitspeed>();
                if (fruit_move.fruit_start_speed >= 0.8f)
                {
                    fruit_move.fruit_start_speed -= 0.25f;
                }
            }
        }

        IEnumerator RestartGame()
        {
            is_it_dead = true;
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
    }
}
