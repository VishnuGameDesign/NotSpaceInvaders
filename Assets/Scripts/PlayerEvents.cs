using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    //triggers an event when the player does the mentioned actions
    public static event Action OnRun;
    public static event Action OnJump;
    public static event Action OnShootUp;
    public static event Action OnShootStraight;
    public static event Action OnLevelComplete;
    public static event Action<Health> OnDeath, OnPlayerDeath;
    public static event Action<Health, int> OnHealthUpdated;


    //Listens for any subscribers
    #region Listeners
    public static void Run()
    {
        OnRun?.Invoke();
    }
    public static void ShootStraight()
    {
        OnShootStraight?.Invoke();
    }
    public static void ShootUp()
    {
        OnShootUp?.Invoke();
    }

    public static void Jump()
    {
        OnJump?.Invoke();
    }

    public static void Dead(Health health)
    {
        OnDeath?.Invoke(health);
    }

    public static void PlayerDeath(Health health)
    {
        OnPlayerDeath?.Invoke(health);
    }
    
    public static void UpdateHealth(Health health, int currentHealth)
    {
        OnHealthUpdated?.Invoke(health, currentHealth);
    }

    public static void LevelComplete()
    {
        OnLevelComplete?.Invoke();
    }

    #endregion
}