using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour
{

    [SerializeField]
    private GameState gameState;
    [SerializeField]
    public InputField player1NameInput;
    [SerializeField]
    public InputField player2NameInput;

    

    public void OnPlayButtonClick()
    {
        // Store player names in GameState
        gameState.Player1Name = player1NameInput.text;
        gameState.Player2Name = player2NameInput.text;

        // Load Scene1
        SceneManager.LoadScene("Scene1");
    }
}
