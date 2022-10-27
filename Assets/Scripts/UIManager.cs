using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject uiScreen;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    private bool isGameOver = false;

    private void OnEnable()
    {
        GameManager.OnScoreUpdated += UpdateScore;
        GameManager.OnLivesUpdated += UpdateLives;
        GameManager.OnGameOver += GameOver;
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    private void OnDisable()
    {
        GameManager.OnScoreUpdated -= UpdateScore;
        GameManager.OnLivesUpdated -= UpdateLives;
        GameManager.OnGameOver -= GameOver;
    }


    // Update score with value from target clicked
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        Debug.Log("Score Udpates");
    }

    public void UpdateLives(int lives)
    {
        livesText.text = lives.ToString();
        
    }


}
