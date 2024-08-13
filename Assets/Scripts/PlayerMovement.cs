using System.Collections;
using System.Collections.Generic;
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
        //referencing the static Object
        var moveInput = PlayerInputHandler.Instance.MoveInput;
        _moveDirection = new Vector2(moveInput.x, 0);
        var moveVelocity = _moveSpeed * Time.fixedDeltaTime * _moveDirection.normalized;
        
        //move rigidbody
        _rigidbody.AddForce(moveVelocity, ForceMode2D.Impulse);
    }

}
