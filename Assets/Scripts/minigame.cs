﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigame : MonoBehaviour
{
    public float first_speed = 15f;
    public float second_speed = 19f;
    public float third_speed = 23f;
    private bool game_won = false;
    private bool first_won = false;
    private bool second_won = false;
    private float first_flag = 1f;
    private float second_flag = 1f;
    private float third_flag = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        GameObject first = GameObject.Find("player1");
        GameObject second = GameObject.Find("player2");
        GameObject third = GameObject.Find("player3");
        if (!first_won)
        {
            first.transform.position += Vector3.left * first_speed * first_flag * Time.deltaTime;
            if (first.transform.position.x > 7.6f)
            {
                first_flag = 1f;
            } else if (first.transform.position.x < -7.5f)
            {
                first_flag = -1f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (first.transform.position.x >= 2.856f && first.transform.position.x <= 4.776f)
                {
                    first_won = true;
                    first_flag = 1f;
                } else
                {
                    first.transform.position = new Vector3(-7.5f, 3.72f, 0);
                    first_flag = 1f;
                }
            }
        } else if (!second_won)
        {
            second.transform.position += Vector3.left * second_speed * second_flag * Time.deltaTime;
            if (second.transform.position.x > 7.6f)
            {
                second_flag = 1f;
            }
            else if (second.transform.position.x < -7.5f)
            {
                second_flag = -1f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (second.transform.position.x >= -4.803f && second.transform.position.x <= -3.523f)
                {
                    second_won = true;
                    second_flag = 1f;
                }
                else
                {
                    first.transform.position = new Vector3(-7.5f, 3.72f, 0);
                    second.transform.position = new Vector3(-7.5f, 0.713f, 0);
                    second_flag = 1f;
                    first_won = false;
                }
            }
        } else if (!game_won)
        {
            third.transform.position += Vector3.left * third_speed * third_flag * Time.deltaTime;
            if (third.transform.position.x > 7.6f)
            {
                third_flag = 1f;
            }
            else if (third.transform.position.x < -7.5f)
            {
                third_flag = -1f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (third.transform.position.x >= 0.465f && third.transform.position.x <= 0.785f)
                {
                    game_won = true;
                    third_flag = 1f;
                }
                else
                {
                    first.transform.position = new Vector3(-7.5f, 3.72f, 0);
                    second.transform.position = new Vector3(-7.5f, 0.713f, 0);
                    third.transform.position = new Vector3(-7.5f, -2.28f, 0);
                    third_flag = 1f;
                    second_won = false;
                    first_won = false;
                }
            }
        } else
        {
            StartCoroutine(RestartGame());
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}