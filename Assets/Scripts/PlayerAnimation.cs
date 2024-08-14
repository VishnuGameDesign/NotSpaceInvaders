using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour

{
    //referencing the absolute move value in this script
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        //subscribe to run and shoot events and plays the animations
        PlayerEvents.OnRun += RunAnim;
        PlayerEvents.OnShoot += ShootAnim;
    }

    private void OnDisable()
    {
        //unsubscribe to run and shoot events 
        PlayerEvents.OnRun -= RunAnim;
        PlayerEvents.OnShoot -= ShootAnim;
    }

    private void Update()
    {
        //The player will only stop in the "right" direction if Math.Abs isnt used
        if(Math.Abs(PlayerInputHandler.Instance.MoveInput.x) < 0.1f)
        {
            PlayAnimation("Speed", 0f);
        }
        
        if(PlayerInputHandler.Instance.ShootUpTriggered == false)
        {
            PlayAnimation("Shoot", false);
        }
    }

    private void RunAnim()
    {
        float speed = _playerMovement.AbsoluteMovement;
        PlayAnimation("Speed", speed);
    }


    private void ShootAnim()
    {
        PlayAnimation("Shoot", true);
    }

    //animation parameter overriding methods
    #region Play Animations
    public void PlayAnimation(string animName, bool value)
    {
        if (_animator == null)
            return;

        _animator.SetBool(animName, value);
    }

    public void PlayAnimation(string animName, float value)
    {
        if (_animator == null)
            return;

        _animator.SetFloat(animName, value);
    }
    #endregion
}
