using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private Text Text;
    public float score = 0f;
    public float speed = 1f;
    public bool is_itdead = false;
    public bool check_dead = false;
    void Awake()
    {
        Text = GameObject.Find("Text").GetComponent<Text> ();
        GameObject score_to_save = GameObject.Find("scoreobject");
        ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
        score = score_saved.saved_score;
        Text.text = score.ToString();
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
                Debug.Log(System.DateTime.Now.TimeOfDay);
                Debug.Log("C2"); // Player lost by collecting bomb
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
                Debug.Log(System.DateTime.Now.TimeOfDay);
                Debug.Log("E"); // Point successfully collected
                GameObject score_to_save = GameObject.Find("scoreobject");
                ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
                score_saved.saved_score = score;
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
