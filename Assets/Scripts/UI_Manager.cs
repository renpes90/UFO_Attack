using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text scoreText;

    public Text gameOverText;

    public Text winText;

    public Button retryGame;

    public Button titleScreen;

    private GameManager gameManager;

    void Start()
    {
        scoreText.text = "Score: " + 0;
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        retryGame.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOverSequence()
    {
        gameManager.GameOver();
        gameOverText.gameObject.SetActive(true);
        retryGame.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(true);
    }

    public void WinSequence()
    {
        gameManager.Win();
        winText.gameObject.SetActive(true);
        retryGame.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(true);
    }
}
