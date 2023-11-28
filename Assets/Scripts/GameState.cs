using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "gameState", menuName = "State/MyGameState")]
public class GameState : ScriptableObject
{
    public int player1Health = 100;
    public int player2Health = 100;
    public int basicEnemyDamage = 40;

    public string Player1Name = "NONAME";
    public string Player2Name = "NONAME2";
}