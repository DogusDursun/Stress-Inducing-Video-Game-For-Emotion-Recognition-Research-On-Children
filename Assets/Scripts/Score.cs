using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private Text Text;
    private int score = 0;
    public float speed = 1f;
    public bool is_itdead = false;
    public bool check_dead = false;
    void Awake()
    {
        Text = GameObject.Find("Text").GetComponent<Text> ();
        Text.text = "000";
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D target) {
        GameObject collectorfound = GameObject.Find("Collector");
        Collector collectorscript = collectorfound.GetComponent<Collector>();
        check_dead = collectorscript.is_it_dead;
        if (!is_itdead && !check_dead)
        {
            if (target.tag == "bomb")
            {
                target.tag = "destroy";
                //transform.position = new Vector2(0, 100);
                StartCoroutine(RemoveAfterSeconds(0.5f, target.gameObject));
                //target.gameObject.SetActive(false);
                StartCoroutine(RestartGame());
            }

            if (target.tag == "point")
            {
                target.tag = "destroy";
                //target.gameObject.SetActive(false);
                StartCoroutine(RemoveAfterSeconds(0.4f, target.gameObject));
                score += 500;
                Text.text = score.ToString();
                GameObject fruit__speed2 = GameObject.Find("fruitspeedholder");
                fruitspeed fruit_move = fruit__speed2.GetComponent<fruitspeed>();
                fruit_move.fruit_start_speed += 0.05f;
            }
        }

        IEnumerator RestartGame()
        {
            is_itdead = true;
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
