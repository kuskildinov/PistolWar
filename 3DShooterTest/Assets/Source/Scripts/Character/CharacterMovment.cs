using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    private const float JumpMultiply = -2f;
    private const float RunMultiply = 2f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _root;
    [SerializeField, Min(0)] private Vector3 _groundCollisionSize;
    [SerializeField, Min(0)] private float _groundCollisionDistance;
    [SerializeField, Min(0)] private float _jumpHeight;
    [SerializeField, Min(0)] private float _walkSpeed;
    [SerializeField, Min(0)] private float _runSpeed;

    private IInput _input;
    private float _horizontal;
    private float _vertical;
    private bool _grounded;
    private float _currentSpeed;

    private void Update()
    {
        ReadInput();
        _currentSpeed = _walkSpeed;
        if (_input.Jump())
        {
            UpdateGroundCollision();
            TryJump();
        }
        if (_input.Run())
        {
            Runing();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveDirection = _root.TransformDirection(new Vector3(_horizontal,0,_vertical));
        _rigidbody.MovePosition(_rigidbody.transform.position + moveDirection * _currentSpeed * Time.fixedDeltaTime);
    }

    private void Runing()
    {
        _currentSpeed = _runSpeed;
    }
    private  void TryJump()
    {
        
    }

    private void UpdateGroundCollision()
    { 

    }

    private void ReadInput()
    {
        _horizontal = _input.HorizontalMove();
        _vertical = _input.VerticalMove();
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }
}
