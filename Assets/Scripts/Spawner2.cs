using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Points = null;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnFruit(1f));
    }

    IEnumerator SpawnFruit(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        float[] number = new float[] { -1.0f, 0f, 1.0f };
        int randomNo = Random.Range(0, 3);
        float randomResult = number[randomNo];
        Vector3 temp = transform.position;
        temp.x = randomResult;
        Instantiate(Points[Random.Range(0, Points.Length)], temp, Quaternion.identity);
        StartCoroutine(SpawnFruit(Random.Range(1f, 2f)));
    }

    // Update is called once per frame
    /* void Update()
     {

     }*/
}
