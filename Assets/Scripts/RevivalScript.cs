using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    // Check if any player is in the revival area
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player1") && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("P1 is reviving P2");
            CanRevivePlayer2();
        }
        
    }

    // Revive both players
    private void CanRevivePlayer2()
    {
        // Revive Player 2
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null)
        {
            Player2CombatScript player2Combat = player2.GetComponent<Player2CombatScript>();
            if (player2Combat != null && gameState.player2Health <= 0)
            {
                RevivePlayer2(player2Combat);
            }
        }
    }

    // Revive a single player
    private void RevivePlayer2(Player2CombatScript player2Combat)
    {
        // Set player health to 100
        gameState.player2Health = 100;

        // Reset death-related states
        player2Combat.animator.SetBool("IsDead", false);
        player2Combat.animator.Play("HeavyBandit_CombatIdle");
        // Enable the Collider for interactions
        player2Combat.GetComponent<Collider2D>().enabled = true;

        // Add the Rigidbody component for physics interactions (if needed)
        Rigidbody2D rb = player2Combat.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = player2Combat.gameObject.AddComponent<Rigidbody2D>();
        }

        // Set gravity scale to 0
        rb.gravityScale = 0;

        // Enable the PlayerMovementScript if found
        if (player2Combat.player2MovementScript != null)
        {
            player2Combat.player2MovementScript.enabled = true;
        }

        // Enable the PlayerCombatScript to resume updates
        player2Combat.enabled = true;
    }

    
}
