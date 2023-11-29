using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    [SerializeField]
    private TextMeshProUGUI errMessageText;

    private string player1NameInput = "";
    private string player2NameInput = "";

    public void StartGame()
    {
        if (string.IsNullOrEmpty(player1NameInput) || string.IsNullOrEmpty(player2NameInput))
        {
            // error
            errMessageText.text = "Both player names are required";
        }
        else
        {
            if (player1NameInput.Trim().Length == 0 || player2NameInput.Trim().Length == 0)
            {
                // error
                errMessageText.text = "Player names cannot be empty";
            }
            else
            {
                gameState.Player1Name = player1NameInput;
                gameState.Player2Name = player2NameInput;
                SceneManager.LoadScene("Scene1");
            }
        }
    }

    public void ReadPlayer1Input(string s)
    {
        player1NameInput = s;
        Debug.Log("Player1 name is " + s);
    }

    public void ReadPlayer2Input(string s)
    {
        player2NameInput = s;
        Debug.Log("Player2 name is " + s);
    }

    public void Start()
    {
        errMessageText.text = "";
    }

    public void Update()
    {
        // You can add any additional update logic here
    }
}
