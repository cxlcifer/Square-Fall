using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    private const string BEST_SCORE = "BestScore";

    [SerializeField] private AudioSource _bestScoreSound;
    [SerializeField] private TextMeshProUGUI _currentScoreLabel;
    [SerializeField] private int _scorePerSquare;

    private int _bestScore;
    private int _currentScore;


    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(BEST_SCORE);
    }

    public void AddScore()
    {
        _currentScore += _scorePerSquare;
        _currentScoreLabel.text = _currentScore.ToString();
    }
    
    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public int GetBestScore()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            PlayerPrefs.SetInt(BEST_SCORE,_bestScore);
            PlayerPrefs.Save();
            _bestScoreSound.Play();
        }
        
        return _bestScore;
    }
}
