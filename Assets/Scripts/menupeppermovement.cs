using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupeppermovement : MonoBehaviour
{
    public float speed = 100f;
    private int flag = 1;
    private int counter = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (counter >= 7)
        {
            if (transform.position.x < 375f && transform.position.x > 365f)
            {
                StartCoroutine(Restart());
            } else
            {
                transform.position += Vector3.left * speed * flag * Time.deltaTime;
            }
        } else
        {
            transform.position += Vector3.left * speed * flag * Time.deltaTime;
            if (transform.position.x > 428f)
            {
                flag = 1;
                counter++;
            }
            else if (transform.position.x < 310f)
            {
                flag = -1;
                counter++;
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(2f);
        transform.position = new Vector3(310.5896f, 249.7166f, 0);
        flag = 1;
        counter = 0;
    }
}
