using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            gameState.player1Health = 100;
            Destroy(gameObject);

        }
        else if (other.CompareTag("Player2"))
        {
            gameState.player2Health = 100;
            Destroy(gameObject);
        }
    }
}
