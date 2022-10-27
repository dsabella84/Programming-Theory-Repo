using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public static event Action<int> OnScoreUpdated;
    public static event Action<int> OnLivesUpdated;
    public static event Action OnGameOver;

    private int currentScore;
    private int currentLives;
    private bool isGameOver = false;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetLevel();
    }

    private void ResetLevel()
    {
        currentLives = 3;
        currentScore = 0;

        UpdateLives(0);
        UpdateScore(0);
    }

    private void OnEnable()
    {
        Food.OnFoodEaten += FoodEaten;
    }

    private void OnDisable()
    {
        Food.OnFoodEaten -= FoodEaten;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);


    }
    
    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        OnScoreUpdated?.Invoke(currentScore);
    }

    public void UpdateLives(int livesToLose)
    {
        currentLives -= livesToLose;
        OnLivesUpdated?.Invoke(currentLives);

        if (currentLives <= 0)
        {
            OnGameOver?.Invoke();
        }
    }


    private void FoodEaten(Food obj)
    {
        UpdateScore(obj.GetScoreValue());
    }

}
