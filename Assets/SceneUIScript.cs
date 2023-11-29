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

    // Placeholder text for Player 1 and Player 2 names
    

    // Start is called before the first frame update
    void Start()
    {
        player1HP.text = "Player1 HP: " + gameState.player1Health.ToString() + "/100";
        player2HP.text = "Player2 HP: " + gameState.player2Health.ToString() + "/100";
    }

    // Update is called once per frame
    void Update()
    {
        player1HP.text = "Player1 HP: " + gameState.player1Health.ToString() + "/100";
        player2HP.text = "Player2 HP: " + gameState.player2Health.ToString() + "/100";
    }
}
