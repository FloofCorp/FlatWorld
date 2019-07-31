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

    private static PMController _charCon;
    private float verticalVel;

    private void Awake()
    {
        _charCon = GetComponent<PMController>();
    }
    public void UpdateMotor()
    {
        ProccessMotion();
    }

    private void ProccessMotion()
    {
        moveVector = new Vector3(moveVector.x, verticalVel, moveVector.z);
    }
}
