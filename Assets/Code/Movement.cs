using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField][Tooltip("The speed the player moves at")] private float _moveSpeed = 5;
    [SerializeField] [Tooltip("The speed the player jumps at")] private float _jumpSpeed = 4;
    private CharacterController _charCon;
    private Vector3 _moveVec;
    private string _state;
    private float gravityValue = 8.5f;

	// Use this for initialization
	void Start () {
        _charCon = GetComponent<CharacterController>();
        _state = "default";

    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case "3D":
                ThreeDMove();
                break;
            default:
                DefaultMove();
                break;
        }
        Jump();
        Gravity();
        _charCon.Move(_moveVec);
        //Alternating between movement styles
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShiftMove();
        }
    }    
    void DefaultMove()
    {
        _moveVec = new Vector3(Input.GetAxis("Horizontal") * _moveSpeed, 0,0);
        _moveVec *= Time.deltaTime;
    }
    void ThreeDMove()
    {
        _moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(_moveVec.magnitude > 1)
        {
            _moveVec.Normalize();
        }
        //Found an issue that would collide with gravity and physics in general. This is the easiest fix I can ssume for now
        _moveVec.x *= _moveSpeed;
        _moveVec.z *= _moveSpeed;
        _moveVec *= Time.deltaTime;
    }
    void Jump()
    {
        if(Input.GetAxis("Jump") > 0 && _charCon.isGrounded)
        {
            _moveVec.y += Input.GetAxis("Jump") * _jumpSpeed;
        }
    }
    void Gravity()
    {
        if (!_charCon.isGrounded)
        {
            _moveVec.y -= gravityValue * Time.deltaTime;
        }
    }
    public void ShiftMove()
    {
        if(_state == "default")
        {
            _state = "3D";
        }
        else
        {
            _state = "default";
        }
    }
    
}
