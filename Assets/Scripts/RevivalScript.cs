using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    private bool playerInRevivalArea = false;

    // Check if any player is in the revival area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            playerInRevivalArea = true;
            Debug.Log("Player1 entered revival area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            playerInRevivalArea = false;
            Debug.Log("Player1 exited revival area");
        }
    }

    private void Update()
    {
        if (playerInRevivalArea && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("P2 is reviving P1");
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
        player2Combat.animator.SetTrigger("Recover");

        // Delayed activation after 0.99 seconds
        Invoke("ActivatePlayer2Scripts", 0.99f);
    }

    // Activate Player2 scripts
    private void ActivatePlayer2Scripts()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null)
        {
            Player2CombatScript player2Combat = player2.GetComponent<Player2CombatScript>();

            // Enable the PlayerMovementScript if found
            if (player2Combat.player2MovementScript != null)
            {
                player2Combat.player2MovementScript.enabled = true;
            }

            // Enable the PlayerCombatScript to resume updates
            player2Combat.enabled = true;
        }
    }
}
