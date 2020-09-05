using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Player;

    public GameObject startBtn;
    public GameObject restartBtn;

    static public bool gameStart = false;

    private void Start()
    {
        startBtn.SetActive(!gameStart);
        restartBtn.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");        
    }

    private void Update()
    {
        if(Player == null)
        {
            restartBtn.SetActive(true);
        }
    }

    public void StartGame()
    {       
        gameStart = true;
        Destroy(startBtn);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        restartBtn.SetActive(false);
    }
}
