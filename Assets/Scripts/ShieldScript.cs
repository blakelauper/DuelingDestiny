using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            // Assuming the player object has a PlayerCombatScript attached
            PlayerCombatScript player1Combat = other.GetComponent<PlayerCombatScript>();

            if (player1Combat != null)
            {
                // Activate invincibility for Player1
                player1Combat.ActivateInvincibility();

                // Destroy the shield object
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Player2"))
        {
            Player2CombatScript player2Combat = other.GetComponent<Player2CombatScript>();
            if (player2Combat != null )
            {
                player2Combat.ActivateInvincibility();
                Destroy(gameObject);
            }
        }
    }
}
