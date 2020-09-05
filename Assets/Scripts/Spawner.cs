using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public float waveTime;

    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(SceneController.gameStart && Player != null)
        {
            waveTime += Time.deltaTime;
            if (waveTime > 1f)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-6.5f, 6.5f), Random.Range(-2.5f, 2.5f));
                Instantiate(zombie, randomPosition, Quaternion.identity);

                waveTime = 0f;
            }
        }
    }
}
