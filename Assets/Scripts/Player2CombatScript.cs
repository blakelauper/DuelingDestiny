using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player2CombatScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    public Transform attackPoint2;
    
    public float attackRange2 = 0.7f;
    public LayerMask enemyLayers;

    public int attackDamage = 50;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    public Animator animator;
    public Player2MovementScript player2MovementScript; // Reference to PlayerMovementScript


    void Start()
    {
        gameState.player2Health = 100;
        player2MovementScript = GetComponent<Player2MovementScript>();
        if (player2MovementScript == null)
        {
            Debug.LogError("Player2MovementScript not found on the same GameObject.");
        }
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }


    public void TakeDamage(int amount)
    {
        if (gameState.player2Health > 0)
        {
            gameState.player2Health -= amount;
            animator.SetTrigger("Hurt");

            if (gameState.player2Health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Play death animation or any other death-related logic
        animator.SetBool("IsDead", true);
        gameState.player2Health = 0;

        // Get the Collider component
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            // Set the Collider to trigger
            collider.isTrigger = true;
        }

        // Remove the Rigidbody component to prevent physics interactions
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Set the Rigidbody to kinematic
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }

        // Disable the PlayerMovementScript if found
        if (player2MovementScript != null)
        {
            player2MovementScript.enabled = false;
        }

        // Disable this script to stop any further updates
        this.enabled = false;
    }


    private void Attack2()
    {
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
        foreach (Collider2D enemy2 in hitEnemies2)
        {
            Debug.Log("We hit " + enemy2.name);
            enemy2.GetComponent<EnemyScript>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint2 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);

    }

    // Handle collisions with enemy objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Assuming enemy deals 40 damage
            TakeDamage(gameState.basicEnemyDamage);
        }
    }
    
}