using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endscore : MonoBehaviour
{
    public float endscore = 0f;
    private Text ScoreText;
    // Start is called before the first frame update
    void Awake()
    {
        ScoreText = GameObject.Find("Text").GetComponent<Text>();
        GameObject score_to_save = GameObject.Find("scoreobject");
        ScoreSaver score_saved = score_to_save.GetComponent<ScoreSaver>();
        endscore = score_saved.saved_score;
        ScoreText.text = endscore.ToString();
    }
}
