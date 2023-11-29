using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Revival2Script : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    // Check if any player is in the revival area
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player2") && Input.GetKeyDown(KeyCode.R))
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

            
                player1Combat = player1.GetComponent<PlayerCombatScript>();
                RevivePlayer1(player1Combat);

            
        }
    }

    // Revive a single player
    private void RevivePlayer1(PlayerCombatScript player1Combat)
    {
        // Set player health to 100
        gameState.player1Health = 100;

        // Reset death-related states
        player1Combat.animator.SetBool("IsDead", false);
        player1Combat.animator.Play("LightBandit_CombatIdle");
        // Enable the Collider for interactions
        player1Combat.GetComponent<Collider2D>().enabled = true;

        // Add the Rigidbody component for physics interactions (if needed)
        Rigidbody2D rb = player1Combat.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = player1Combat.gameObject.AddComponent<Rigidbody2D>();
        }

        // Set gravity scale to 0
        rb.gravityScale = 0;

        // Enable the PlayerMovementScript if found
        if (player1Combat.playerMovementScript != null)
        {
            player1Combat.playerMovementScript.enabled = true;
        }

        // Enable the PlayerCombatScript to resume updates
        player1Combat.enabled = true;
    }
}
