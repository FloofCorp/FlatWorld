using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 5;
    private CharacterController _charCon;
    private Vector3 _moveVec;
    private string _state;

	// Use this for initialization
	void Start () {
        _charCon = GetComponent<CharacterController>();
        _state = "default";

    }
	
	// Update is called once per frame
	void Update () {
        switch (_state)
        {
            case "3D":
                ThreeDMove();
                break;
            default:
                DefaultMove();
                break;
        }
        _charCon.Move(_moveVec);
        //Alternating between movement styles
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShiftMove();
        }

	}
    void DefaultMove()
    {
        _moveVec = new Vector3(Input.GetAxis("Horizontal"),0,0);
        _moveVec *= _moveSpeed;
        _moveVec *= Time.deltaTime;
    }
    void ThreeDMove()
    {
        _moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(_moveVec.magnitude > 1)
        {
            _moveVec.Normalize();
        }
        _moveVec *= _moveSpeed;
        _moveVec *= Time.deltaTime;
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
