using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;

    public GameObject effectPlayerDead;
    public GameObject effectDead;

    private Animator anim;

    private bool born = false;
    private float timeToBorn = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if(Player != null && born)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.fixedDeltaTime);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void Update()
    {
        timeToBorn += Time.deltaTime;
        if(timeToBorn > 1f)
        {
            born = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(born)
        {
            if (col.tag == "Sword")
            {
                Instantiate(effectDead, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                PlayerMovement.scoreValue++;
            }
            if (col.tag == "Player")
            {
                Instantiate(effectPlayerDead, Player.transform.position, Quaternion.identity);
                Destroy(Player.gameObject);
                AdsManager.Instance.ShowVideoAd();
            }
        }
    }
}
