using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    Rigidbody2D rb;
    float MOVE_SPEED = 6.0f;
    float JUMP_FORCE = 7.5f;
    float xDirection = 0.0f;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xDirection * MOVE_SPEED, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, JUMP_FORCE);
        }

        if (xDirection > 0.0f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (xDirection < 0.0f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }

}
