using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection;
    
    //movement variables
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    //ground 
    private bool _isGrounded;
    private float _groundedDistance = 0;
    [SerializeField] private Vector2 _groundedBoxCastSize;
    [SerializeField] private Vector3 _groundedBoxCastOffset;
    [SerializeField] private LayerMask _layermask;

    public float AbsoluteMovement {get; private set;}


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //fn. to move in x direction
        HandleMovement();
        _isGrounded = GroundCheck();
        Debug.Log(_isGrounded);
        HandleJumping();
    }

    private void HandleMovement()
    {
        //referencing the static Object - gets input
        var moveInput = PlayerInputHandler.Instance.MoveInput;
        _moveDirection = new Vector2(moveInput.x, 0).normalized;

        //returns absolute value of x - converts negative to its positive equivalent 
        AbsoluteMovement = Math.Abs(moveInput.x);
        
        //face the correct direction 
        if( AbsoluteMovement > 0.1)
        {
            //Binds to the run event
            PlayerEvents.Run();
            var facingAngle = moveInput.x < 0f ? 180f : 0f;
            //had scaling issues when used quaternion.euler
            transform.eulerAngles = new Vector3(0, facingAngle, 0);
        }

        //move 
        _rigidbody.AddForce(_moveDirection * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void HandleJumping()
    {
        if((PlayerInputHandler.Instance.JumpTriggered && _isGrounded) == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        var start = transform.position + _groundedBoxCastOffset;
        var end = new Vector3(start.x, start.y - _groundedDistance, start.z);

        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawWireCube(end, _groundedBoxCastSize);
    }

    private bool GroundCheck()
    {
        var originPosition = transform.position + _groundedBoxCastOffset;
        var direction = Vector2.down;

        var hits = Physics2D.BoxCastAll(originPosition, _groundedBoxCastSize, 0, direction, _groundedDistance, _layermask);
       
        if(hits != null && hits.Length > 0)
        {
            return true;
        }
        return false;

    }

}
