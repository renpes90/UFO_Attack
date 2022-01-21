using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public bool isWin;

    private void Start()
    {
        isGameOver = false;
        isWin = false;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void Win()
    {
        isWin = true;
    }
}
