using System.Collections;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    float MOVE_SPEED = 6.0f;
    bool canAttack = true;
    float attackCooldown = 1f;
    
    private enum AnimationStateEnum
    {
        Idle = 0,
        Running = 1,
        Attacking = 3
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }
   
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Period) && canAttack)
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

        // Clamp player position to stay within camera bounds
        ClampPlayerPosition();
    }

    private void Move()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1.0f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1.0f;
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize(); // Ensure that diagonal movement is not faster

        rb.velocity = new Vector2(movement.x * MOVE_SPEED, movement.y * MOVE_SPEED);

        if (movement.x > 0.0f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x < 0.0f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void SetAnimationState()
    {
        AnimationStateEnum playerAnimationState;

        if (rb.velocity.magnitude < 0.01f)
        {
            playerAnimationState = AnimationStateEnum.Idle;
        }
        else
        {
            playerAnimationState = AnimationStateEnum.Running;
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

    private void ClampPlayerPosition()
    {
        Vector3 playerPos = transform.position;

        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        float maxY = Camera.main.transform.position.y + cameraHalfHeight - 1.5f; // Adjust the offset as needed
        float minY = Camera.main.transform.position.y - cameraHalfHeight;
        float maxX = Camera.main.transform.position.x + cameraHalfWidth - 1f;
        float minX = Camera.main.transform.position.x - cameraHalfWidth + 1f;

        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);

        transform.position = playerPos;
    }


}
