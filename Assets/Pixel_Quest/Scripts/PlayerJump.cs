using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce = 5;
  
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;
    
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool groundCheck;
    private bool waterCheck;

    private float FallForce = 2;
    private Vector2 gravityVector;

    // Start is called before the first frame update
    void Start()
    {
        gravityVector = new Vector2(0, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Water") { waterCheck = true; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Water") { waterCheck = false; }
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = Physics2D.OverlapCapsule(feetCollider.position,
           new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal,
           0, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && (groundCheck || waterCheck)) 
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        if (rb.velocity.y < 0 && !waterCheck)
        {
            rb.velocity += gravityVector * (FallForce * Time.deltaTime);
        }
    }
}
