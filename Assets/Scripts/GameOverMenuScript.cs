using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenuScript : MonoBehaviour
{
    public GameObject gameOverMenu;
    [SerializeField]
    GameState gameState;

    [SerializeField]
    private TextMeshProUGUI gameOver;

    private void Start()
    {
        gameState.Player1Dead = false;
        gameState.Player2Dead = false;
        gameOver.text = "----------------------- GAME OVER! -----------------------";
    }

    private void Update()
    {
        if (gameState.Player1Dead && gameState.Player2Dead)
        {
            EnableGameOverMenu();
        }
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
