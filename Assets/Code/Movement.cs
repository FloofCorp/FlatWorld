using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField][Tooltip("The speed the player moves at")] private float _moveSpeed = 5;
    [SerializeField] [Tooltip("The speed the player jumps at")] private float _jumpSpeed = 4;
    private CharacterController _charCon;
    private Vector3 _moveVec;
    private string _state;
    private float gravityValue = 19f;

    private void Start()
    {
        _charCon = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //restart the movement
        _moveVec = Vector3.zero;
        //Take input
        _moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //Taking the move speed
        _moveVec.x *= _moveSpeed;
        ApplyGravity();
        _moveVec *= Time.deltaTime;

        _charCon.Move(_moveVec);
    }
    private void ApplyGravity()
    {
        if (!_charCon.isGrounded)
        {
            _moveVec.y -= gravityValue * Time.deltaTime;
        }
    }
    private void Jump()
    {
        if(Input.GetAxis("Jump") > 0 && _charCon.isGrounded)
        {

        }
    }

}
