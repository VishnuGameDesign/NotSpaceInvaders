using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private int _playerTeam;

    void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += BackToMainMenu;
        PlayerEvents.OnLevelComplete += LoadLevel;
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= BackToMainMenu;
        PlayerEvents.OnLevelComplete -= LoadLevel;
    }

    private void BackToMainMenu(Health health)
    {
        if(health.Team == _playerTeam)
        {
            LoadLevel();
        }
    }
}
