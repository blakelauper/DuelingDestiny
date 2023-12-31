using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCombatScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public LayerMask enemyLayers;

    private int keysNeeded = 5;

    public int attackDamage = 50;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    bool isInvincible;
    public Animator animator;
    public PlayerMovementScript playerMovementScript; // Reference to PlayerMovementScript


    void Start()
    {
        isInvincible = false; gameState.P1isInvincible = false;
        gameState.player1Health = 100;
        animator = GetComponent<Animator>();
        playerMovementScript = GetComponent<PlayerMovementScript>();
        if (playerMovementScript == null)
        {
            Debug.LogError("PlayerMovementScript not found on the same GameObject.");
        }
        gameState.keyCount = 0;
        gameState.keysNeeded = keysNeeded;
    }
    


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }
    

    public void TakeDamage(int amount)
    {
        if (gameState.player1Health > 0)
        {
            gameState.player1Health -= amount;
            animator.SetTrigger("Hurt");

            if (gameState.player1Health <= 0)
            {
                
                Die();
            }
        }
    }

    private void Die()
    {
        // Play death animation or any other death-related logic
        animator.SetBool("IsDead", true);
        gameState.player1Health = 0;
        gameState.Player1Dead = true;
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
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        // Disable this script to stop any further updates
        this.enabled = false;
    }


    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // Handle collisions with enemy objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInvincible == false)
        {
            if (other.CompareTag("Enemy"))
            {
                // Assuming enemy deals 40 damage
                TakeDamage(gameState.basicEnemyDamage);
            }
            else if (other.CompareTag("Enemy2"))
            {
                TakeDamage(gameState.Enemy2Damage);
            }
            else if (other.CompareTag("Boss1"))
            {
                TakeDamage(gameState.BossDamage);
            }
            else if (other.CompareTag("DoubleTeam"))
            {
                TakeDamage(gameState.DoubleTeam);
            }
        }
    }

    public void ActivateInvincibility()
    {
        isInvincible = true;
        gameState.P1isInvincible = true;
        StartCoroutine(DeactivateInvincibilityAfterDelay());
    }

    // Coroutine to deactivate invincibility after a delay (e.g., 10 seconds)
    private IEnumerator DeactivateInvincibilityAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        isInvincible = false;
        gameState.P1isInvincible = false;
    }

}