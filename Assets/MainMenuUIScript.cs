using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private TextMeshProUGUI player1NameText;
    [SerializeField]
    private TextMeshProUGUI player2NameText;

    // Placeholder text for Player 1 and Player 2 names
    private string player1Placeholder = "Enter Player1 Name";
    private string player2Placeholder = "Enter Player2 Name";

    // Start is called before the first frame update
    void Start()
    {
        player1NameText.text = player1Placeholder;
        player2NameText.text = player2Placeholder;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed
    }
}
