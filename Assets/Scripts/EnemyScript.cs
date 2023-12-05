using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    private EnemyMovementScript movementScript; // Reference to EnemyMovementScript
    private BossMovementScript bossMovementScript;
    // Despawn delay in seconds
    private float despawnDelay = 20f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // Try to find and assign the EnemyMovementScript
        movementScript = GetComponent<EnemyMovementScript>();
        if (movementScript == null)
        {
            Debug.LogError("EnemyMovementScript not found on the same GameObject.");
        }
        bossMovementScript = GetComponent<BossMovementScript>();
        if (bossMovementScript == null)
        {
            Debug.LogError("BossMovementScript not on object");
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
        if (bossMovementScript != null)
        {
            bossMovementScript.enabled = false;
        }
        // Schedule despawn after the specified delay
        Invoke("Despawn", despawnDelay);
    }

    private void Despawn()
    {
        // Destroy the GameObject after the delay
        Destroy(gameObject);
    }
}
