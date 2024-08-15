using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    //input action asset 
    [SerializeField] private InputActionAsset _playerControls;
    //input actions 
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _shootUpAction;
    private InputAction _shootStraightAction;

    //getters
    public Vector2 MoveInput {get; private set;}
    public bool JumpTriggered {get; private set;}
    public bool ShootUpTriggered {get; private set;}
    public bool ShootStraightTriggered {get; private set;}

    //singleton
    public static PlayerInputHandler Instance; 

    private void Awake()
    {
        //instantiated null check
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            return;
        }

        _moveAction = _playerControls.FindActionMap("Player").FindAction("Move");
        _jumpAction = _playerControls.FindActionMap("Player").FindAction("Jump");
        _shootUpAction = _playerControls.FindActionMap("Player").FindAction("ShootUp");
        _shootStraightAction = _playerControls.FindActionMap("Player").FindAction("ShootStraight");
        //register ia
        RegisterInputActions();

    }

    private void RegisterInputActions()
    {
        
        _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveAction.canceled += context => MoveInput = Vector2.zero;

        _jumpAction.performed += context => JumpTriggered = true; 
        _jumpAction.canceled += context => JumpTriggered = false; 
        
        _shootUpAction.performed += context => ShootUpTriggered = true; 
        _shootUpAction.canceled += context => ShootUpTriggered = false; 
        
        _shootStraightAction.performed += context => ShootStraightTriggered = true; 
        _shootStraightAction.canceled += context => ShootStraightTriggered = false; 
    }

    //enable
    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
        _shootUpAction.Enable();
        _shootStraightAction.Enable();
    }
    //disable
    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
        _shootUpAction.Disable();
        _shootStraightAction.Disable();
    }
}
