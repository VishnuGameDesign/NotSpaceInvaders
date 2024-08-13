using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //fn. to move in x direction
        HandleMovement();
    }

    private void HandleMovement()
    {
        //referencing the static Object - gets input
        var moveInput = PlayerInputHandler.Instance.MoveInput;
        _moveDirection = new Vector2(moveInput.x, 0);

        //face the right direction 
        if(Math.Abs(moveInput.x) > 0.1)
        {
            var facingAngle = moveInput.x < 0f ? 180f : 0f;

            //had scaling issues when used quaternion.euler
            transform.eulerAngles = new Vector3(0, facingAngle, 0);
        }
        //move 
        _rigidbody.AddForce(_moveDirection * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

}
