using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WMenuScript : MonoBehaviour
{
    public GameObject VictoryMenu;
    [SerializeField]
    GameState gameState;

    [SerializeField]
    private TextMeshProUGUI Victory;

    private void Start()
    {
        gameState.bossCount = 4;
        Victory.text = "----------------------- VICTORY! -----------------------";
    }

    private void Update()
    {
        if (gameState.bossCount == 0)
        {
            EnableVictoryMenu();
        }
    }

    public void EnableVictoryMenu()
    {
        VictoryMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
