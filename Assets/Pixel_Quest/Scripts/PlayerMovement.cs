using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    public int speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        if (xInput < 0)
        {
            spr.flipX = false;
        }
        else if (xInput > 0)
        {
            spr.flipX = true;
        }
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
}
