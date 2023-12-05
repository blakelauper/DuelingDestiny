using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "gameState", menuName = "State/MyGameState")]
public class GameState : ScriptableObject
{
    public int player1Health = 100;
    public int player2Health = 100;

    public int basicEnemyDamage = 40;
    public int Enemy2Damage = 50;
    public int BossDamage = 99;
    public int DoubleTeam = 25;

    public int keyCount = 0;
    public int keysNeeded = 5;

    public string Player1Name = "NONAME";
    public string Player2Name = "NONAME2";

    public bool P1isInvincible = false;
    public bool P2isInvincible = false;
}
