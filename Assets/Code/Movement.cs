using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField][Tooltip("The speed the player moves at")] private float _moveSpeed = 5;
    [SerializeField][Tooltip("The speed the player jumps at")] private float _jumpSpeed = 18;
    [SerializeField] [Tooltip("Using gravity")] private float _gravity = Physics.gravity.y;
    [SerializeField][Tooltip("The speed used when the player dashes")] private float _dashSpeed = 20;
    private CharacterController _charCon;
    private Vector3 _moveVec;
    private string _state;
    private bool _facingRight;

    public bool IsGrounded;
    

    private void Awake()
    {
        _charCon = gameObject.GetComponent<CharacterController>();
    }
    private void Update()
    {
        ApplyGravity();
        //Take input
        if (_charCon.isGrounded)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                _facingRight = true;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                _facingRight = false;
            }
                _moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if(Input.GetAxis("Jump") > 0)
            {
                Jump();
            }
            _moveVec.x *= _moveSpeed;
        }
        //Taking the move speed
        AirDash();
        _moveVec *= Time.deltaTime;
        _charCon.Move(_moveVec);
    }

    private void Jump()
    {
        _moveVec.y += _jumpSpeed * Time.deltaTime;
        IsGrounded = false;
    }

    private void ApplyGravity()
    {
        if(_charCon.isGrounded == false)
        {
            _moveVec.y += _gravity;
        }
        if (_charCon.isGrounded)
        {
            IsGrounded = true;
        }
    }

    private void AirDash()
    {
        if (IsGrounded == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (_facingRight)
                {
                    _moveVec += Vector3.right * _dashSpeed;
                }
                else
                {
                    _moveVec += Vector3.left * _dashSpeed;
                }
            }
        }
    }
}
