using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PMMotor))]
[RequireComponent(typeof(CharacterController))]
public class PMController : MonoBehaviour {
    /*
     * This script's sole purpose is to handle the inputs. By spliting up the code for moving and handling gravity based inputs, I hope to make the movement system better
     */
    public static CharacterController CharCon;
    public static PMMotor motor;

	// Use this for initialization
	void Awake() {
        CharCon = GetComponent<CharacterController>();
        motor = GetComponent<PMMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        motor.UpdateMotor();
        GetLocomotionInput();
        CharCon.Move(motor.moveVector);
	}
    void GetLocomotionInput()
    {
        motor.moveVector = Vector3.zero;
        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            motor.moveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
    }
}
