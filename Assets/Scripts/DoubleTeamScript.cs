using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTeamScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    private EnemyMovementScript movementScript; // Reference to EnemyMovementScript
    private BossMovementScript bossMovementScript;
    // Despawn delay in seconds
    private float despawnDelay = 20f;

    private bool p1Collided = false;
    private bool p2Collided = false;

    // Start is called before the first frame update
    void Start()
    {
        p1Collided = false;
        p2Collided = false ;
        currentHealth = maxHealth;
        // Try to find and assign the EnemyMovementScript
        movementScript = GetComponent<EnemyMovementScript>();
        if (movementScript == null)
        {
            
            Debug.LogError("EnemyMovementScript not found on the same GameObject.");
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a player
        if (collision.gameObject.CompareTag("Player1"))
        {
            p1Collided = true;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            p2Collided = true;
        }

    }
    private void Update()
    {
        if (p1Collided == true && p2Collided  == true)
        {
            TakeDamage(400);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Make enemy position static
        Debug.Log("Enemy Died");

        animator.SetBool("IsDead", true);

        // Disable the Collider to prevent further interactions
        GetComponent<Collider2D>().enabled = false;

        // Remove the Rigidbody component to prevent physics interactions
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Destroy(rb);
        }

        // Disable the EnemyMovementScript if found
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
        gameState.bossCount--;
        // Schedule despawn after the specified delay
        Invoke("Despawn", despawnDelay);
    }

    private void Despawn()
    {
        // Destroy the GameObject after the delay
        Destroy(gameObject);
    }
}
