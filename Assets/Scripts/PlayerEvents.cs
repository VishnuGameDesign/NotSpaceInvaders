using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    //triggers an event when the player does the mentioned actions
    public static event Action OnRun;
    public static event Action OnShoot;


    public static void Run()
    {
        //Listens for any subscribers
        OnRun?.Invoke();
    }
    
    public static void Shoot()
    {
        OnShoot?.Invoke();
    }
}
