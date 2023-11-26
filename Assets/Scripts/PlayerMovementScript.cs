using System.Collections;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    float MOVE_SPEED = 6.0f;
    float JUMP_FORCE = 7.5f;
    bool isGrounded = false;
    bool canAttack = true;
    float attackCooldown = 2.0f;

    private enum AnimationStateEnum
    {
        Idle = 0,
        Running = 1,
        Jumping = 2,
        Attacking = 3
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1.0f);
        }
        else
        {
            Move(0.0f);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.B) && canAttack)
        {
            StartCoroutine(AttackCooldown());
            animator.SetInteger("PlayerState", (int)AnimationStateEnum.Attacking);

            // Start a coroutine to reset the animation state after 2 seconds
            StartCoroutine(ResetAnimationStateAfterDelay(0.8f));
        }
        else
        {
            SetAnimationState();
        }
    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * MOVE_SPEED, rb.velocity.y);

        if (direction > 0.0f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction < 0.0f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JUMP_FORCE);
    }

    private void SetAnimationState()
    {
        AnimationStateEnum playerAnimationState;

        if (isGrounded)
        {
            if (rb.velocity.x == 0.0f)
            {
                playerAnimationState = AnimationStateEnum.Idle;
            }
            else
            {
                playerAnimationState = AnimationStateEnum.Running;
            }
        }
        else
        {
            playerAnimationState = AnimationStateEnum.Jumping;
        }

        animator.SetInteger("PlayerState", (int)playerAnimationState);
    }

    private IEnumerator ResetAnimationStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset animation state to Idle
        animator.Play("LightBandit_CombatIdle");
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
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
