using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWallScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player
        if (collision.gameObject.CompareTag("Player1") && collision.gameObject.CompareTag("Player2"))
        {
            if (gameState.keyCount == gameState.keysNeeded)
            {
                Destroy(gameObject);
            }
        }
    }
}
