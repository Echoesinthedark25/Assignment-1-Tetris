using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TetrisManager : MonoBehaviour
{
    public int score { get; private set; }

    public float timeLeft;
    public TextMeshProUGUI timerText;

    public bool gameOver { get; private set; }

    public UnityEvent OnScoreChanged;
    public UnityEvent OnGameOver;
     

    void Start()
    {
        SetGameOver(false);
    }

    public int CalculateScore(int linesCleared)
    {
        switch (linesCleared)
        {
            case 1: return 100;
            case 2: return 300;
            case 3: return 500;
            case 4: return 800;
            default: return 0;
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke();
    }

    public void SetGameOver(bool _gameOver)
    {
        if (!_gameOver)
        {
            score = 0;
            ChangeScore(0);
        }
        
        gameOver = _gameOver;
        OnGameOver.Invoke();
    }

    //Add public void for timer
    public void countdown()
    {
        timeLeft -= Time.deltaTime;

        //If timer is less than 0, trigger game over.
        if (timeLeft <= 0)
        {
            SetGameOver(true);
        }
       
    }

    public void timerUI()
    {
        timerText.text = $"TIME: {timeLeft:n0}";
    }
   
}
