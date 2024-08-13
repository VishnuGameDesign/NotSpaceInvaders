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
    private InputAction _shootAction;

    //getters
    public Vector2 MoveInput {get; private set;}
    public bool ShotTriggered {get; private set;}

    //singleton
    public static PlayerInputHandler Instance; 

    //instance
    private void Awake()
    {
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
        _shootAction = _playerControls.FindActionMap("Player").FindAction("Shoot");
        //register ia
        RegisterInputActions();

    }

    private void RegisterInputActions()
    {
        
        _moveAction.performed += context => 
        {
            MoveInput = context.ReadValue<Vector2>();
            //Returns vector directions
            //Debug.Log("MoveInput" + MoveInput);
        };
        _moveAction.canceled += context => MoveInput = Vector2.zero;

        _shootAction.performed += context => ShotTriggered = true; 
        _shootAction.canceled += context => ShotTriggered = false; 
    }

    //enable
    private void OnEnable()
    {
        _moveAction.Enable();
        _shootAction.Enable();
    }
    //disable
    private void OnDisable()
    {
        _moveAction.Disable();
        _shootAction.Disable();
    }
}
