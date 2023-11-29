using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Revival2Script : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    private bool playerInRevivalArea = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            playerInRevivalArea = true;
            Debug.Log("Player2 entered revival area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            playerInRevivalArea = false;
            Debug.Log("Player2 exited revival area");
        }
    }

    private void Update()
    {
        if (playerInRevivalArea && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("P2 is reviving P1");
            CanRevivePlayer1();
        }
    }

    // Revive both players
    private void CanRevivePlayer1()
    {
        // Revive Player 1
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null)
        {
            PlayerCombatScript player1Combat = player1.GetComponent<PlayerCombatScript>();

            if (player1Combat != null && gameState.player1Health <= 0)
            {
                RevivePlayer1(player1Combat);
            }
        }
    }

    // Revive a single player
    private void RevivePlayer1(PlayerCombatScript player1Combat)
    {
        // Set player health to 100
        gameState.player1Health = 100;

        // Reset death-related states
        player1Combat.animator.SetBool("IsDead", false);
        player1Combat.animator.SetTrigger("Recover");

        Invoke("ActivatePlayer1Scripts", 0.99f);
    }

    // Activate Player2 scripts
    private void ActivatePlayer1Scripts()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player1");
        if (player2 != null)
        {
            PlayerCombatScript player2Combat = player2.GetComponent<PlayerCombatScript>();

            // Enable the PlayerMovementScript if found
            if (player2Combat.playerMovementScript != null)
            {
                player2Combat.playerMovementScript.enabled = true;
            }

            // Enable the PlayerCombatScript to resume updates
            player2Combat.enabled = true;
        }
    }
}
