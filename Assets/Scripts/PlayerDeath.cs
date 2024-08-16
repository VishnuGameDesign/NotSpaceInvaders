using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private int _playerTeam;

    void Start()
    {
        PlayerEvents.OnPlayerDeath += BackToMainMenu;
    }

    private void BackToMainMenu(Health health)
    {
        if(health.Team == _playerTeam)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
