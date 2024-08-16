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
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= BackToMainMenu;
    }

    private void BackToMainMenu(Health health)
    {
        if(health.Team == _playerTeam)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
