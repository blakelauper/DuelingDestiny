using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyWallScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;

    // Keep track of the number of players touching the object
    private int playersTouching = 0;
    private void Start()
    {
        gameState.keyCount = 5;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a player
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            // Increment the count of players touching the object
            playersTouching++;

            // Check if both players are touching the object
            if (playersTouching >= 2 && gameState.keyCount >= gameState.keysNeeded)
            {
                // Destroy the object if both players are touching and key count is sufficient
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if a player is leaving the object
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            // Decrement the count of players touching the object
            playersTouching = Mathf.Max(0, playersTouching - 1);
        }
    }
}
