using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PMController))]
public class PMMotor : MonoBehaviour {
    public Vector3 moveVector;

    [SerializeField] private float _walkSpeed = 10f;
    [SerializeField] private float _jumpSpeed =6f;
    [SerializeField] private float _gravity = 9.81f;

    private bool _isfalling = false;

    private static CharacterController _god;
    private static PMController _charCon;
    private float verticalVel;

    private void Awake()
    {
        _charCon = GetComponent<PMController>();
        _god = GetComponent<CharacterController>();
    }
    public void UpdateMotor()
    {
        ProccessMotion();
        GiveThrotle();
    }

    private void ProccessMotion()
    {
        moveVector = new Vector3(moveVector.x, verticalVel, moveVector.z);
    }
    private void GiveThrotle()
    {
        moveVector.x *= _walkSpeed;
        moveVector *= Time.deltaTime;
    }
    private void GravityDrive()
    {
        //If the i'm grounded, begin generating gravity
        if (!_god.isGrounded)
        {
            verticalVel = Mathf.Lerp(verticalVel, _gravity, Time.deltaTime);
        }
    }
}
