using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {    
    [SerializeField] private Transform _target;     //Target the camera is looking at
    [SerializeField] private float _timeDilation = 4;
    [SerializeField] private float _zOffset = 4;        //Offset on the Z Axis

    private Vector3 newTransform;
    // Use this for initialization
    void Start () {
		if(_target == null)
        {
            _target = GameObject.FindWithTag("Player").transform;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        newTransform = new Vector3(_target.position.x, _target.position.y, _target.position.z - _zOffset);
        transform.position = Vector3.LerpUnclamped(transform.position, newTransform, _timeDilation * Time.deltaTime);
	}
}
