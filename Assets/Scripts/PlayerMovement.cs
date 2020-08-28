using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 2f;
    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0, 0);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
