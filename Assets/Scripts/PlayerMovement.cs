using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject sword;

    private Vector2 moveAmount;
    private Vector2 moveSword;

    private bool isDashButtonDown;

    public TextMeshProUGUI scoreText;
    static public int scoreValue = 0;
    private void Start()
    {
        scoreValue = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        moveSword = moveInput.normalized;

        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }        
        FollowSword();

        scoreText.text = scoreValue.ToString();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

        if(isDashButtonDown)
        {
            rb.MovePosition(rb.position + moveAmount * 0.3f);
            isDashButtonDown = false;
        }
    }

    private void FollowSword()
    {
        if(moveAmount != Vector2.zero)
        {
            Vector2 direction = sword.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sword.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            sword.transform.localPosition = moveSword;
        }
    }
}
