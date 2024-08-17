using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{
    private int _score;
    private int _winningScore = 10;
    [SerializeField] private int _playerTeam;
    private TextMeshProUGUI _scoreLabel;

    void Start()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
        UpdateScore();
        PlayerEvents.OnDeath += DisplayScore;
    }

    //updates the score when enemies are killed 
    private void DisplayScore(Health thisObject)
    {
        if(thisObject.Team != _playerTeam)
        {
            _score++;
            UpdateScore();
        }
        //if 10 enemies are killed, player wins and loads the menu screen 
        if(_score == _winningScore)
        {
            PlayerEvents.LevelComplete();
        }
    }

    private void UpdateScore()
    {
        _scoreLabel.text = "Alien Kill Count: " + _score;
    }
}
