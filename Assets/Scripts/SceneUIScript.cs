using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneUIScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private TextMeshProUGUI player1HP;
    [SerializeField]
    private TextMeshProUGUI player2HP;
    [SerializeField]
    private TextMeshProUGUI player1Shield;
    [SerializeField]
    private TextMeshProUGUI player2Shield;
    [SerializeField]
    private TextMeshProUGUI Keys;
    // Placeholder text for Player 1 and Player 2 names


    // Start is called before the first frame update
    void Start()
    {
        player1HP.text = gameState.Player1Name + "'s HP: " + gameState.player1Health.ToString() + "/100";
        player2HP.text = gameState.Player2Name + "'s HP: " + gameState.player2Health.ToString() + "/100";
        player1Shield.text = "";
        player2Shield.text = "";
        Keys.text = "You have " + gameState.keyCount.ToString() + " / " + gameState.keysNeeded.ToString() + " keys!";
    }

    // Update is called once per frame
    void Update()
    {
        player1HP.text = gameState.Player1Name + "'s HP: " + gameState.player1Health.ToString() + "/100";
        player2HP.text = gameState.Player2Name + "'s HP: " + gameState.player2Health.ToString() + "/100";
        Keys.text = "You have " + gameState.keyCount.ToString() + " / " + gameState.keysNeeded.ToString() + " keys!";
        if (gameState.P1isInvincible)
        {
            player1Shield.text = gameState.Player1Name + " is Invincible!";
        }
        else if (gameState.P1isInvincible == false)
        {
            player1Shield.text = "";
        }


        if (gameState.P2isInvincible)
        {
            player2Shield.text = gameState.Player2Name + " is Invincible!";
        }
        else if (gameState.P2isInvincible == false)
        {
            player2Shield.text = "";
        }
    }
}
