using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BugScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text Text;
    public float score = 0f;
    public float speed = 1f;
    public bool is_itdead = false;
    public bool check_dead = false;
    public bool bug_time = false;
    void Awake()
    {
        Text = GameObject.Find("Text").GetComponent<Text>();
        GameObject score_to_save = GameObject.Find("scoreobject");
        ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
        score = score_saved.saved_score;
        Text.text = score.ToString();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        GameObject collectorfound = GameObject.Find("Collector");
        Collector collectorscript = collectorfound.GetComponent<Collector>();
        check_dead = collectorscript.is_it_dead;
        if ((collectorscript.drop_counter >= 6) && (!bug_time))
        {
            /*Debug.Log(System.DateTime.Now);
            Debug.Log("ENTERED INTO BUG MODE");*/
            bug_time = true;
        }
        if (!is_itdead && !check_dead)
        {
            if (target.tag == "bomb")
            {
                target.tag = "destroy";
                Debug.Log(System.DateTime.Now);
                Debug.Log("PLAYER HAS LOST BY COLLECTING A BOMB");
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
                if (!bug_time)
                {
                    StartCoroutine(RemoveAfterSeconds(0.4f, target.gameObject));
                    score += 500;
                    Debug.Log(System.DateTime.Now);
                    Debug.Log("Successfully collected point. Total point: " + score);
                    Text.text = score.ToString();
                    GameObject score_to_save = GameObject.Find("scoreobject");
                    ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
                    score_saved.saved_score = score;
                    GameObject fruit__speed2 = GameObject.Find("fruitspeedholder");
                    fruitspeed fruit_move = fruit__speed2.GetComponent<fruitspeed>();
                    fruit_move.fruit_start_speed += 0.05f;
                } else
                {
                    Debug.Log(System.DateTime.Now);
                    Debug.Log("PLAYER HAS LOST BY COLLECTING A BUGGED POINT");
                    GameObject score_to_save = GameObject.Find("scoreobject");
                    ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
                    score_saved.saved_score = score;
                    StartCoroutine(RemoveAfterSeconds(0.5f, target.gameObject));
                    StartCoroutine(RestartGame());
                }
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
