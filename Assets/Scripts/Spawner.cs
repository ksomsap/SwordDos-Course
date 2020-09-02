using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public float waveTime;
    void Update()
    {
        waveTime += Time.deltaTime;
        if(waveTime > 2)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-6.5f, 6.5f), Random.Range(-2.5f, 2.5f));
            Instantiate(zombie, randomPosition, Quaternion.identity);

            waveTime = 0f;
        }
    }
}
