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


    //Listens for any subscribers
    #region OnAction
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


    #endregion
}