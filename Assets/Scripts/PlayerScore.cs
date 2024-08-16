using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScore : MonoBehaviour
{
    private int _score;
    [SerializeField] private int _playerTeam;
    private TextMeshProUGUI _scoreLabel;

    void Start()
    {
        _scoreLabel = GetComponent<TextMeshProUGUI>();
        UpdateScore();
        PlayerEvents.OnDeath += DisplayScore;
    }

    private void DisplayScore(Health thisObject)
    {
        if(thisObject.Team != _playerTeam)
        {
            _score++;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        _scoreLabel.text = "Alien Kill Count: " + _score;
    }
}
