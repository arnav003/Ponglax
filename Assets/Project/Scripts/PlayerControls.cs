using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {


	public Camera mainCamera;
	public Vector3 cameraOffset;
	public bool isMoveLeftButtonPressed = false;
	public bool isMoveRightButtonPressed = false;

	public KeyCode moveLeft;
	public KeyCode moveRight;
	public float speed = 10.0f;
	public float boundZ = 4.75f;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{		
        var pos = transform.position;
        if (pos.z > boundZ)
        {
            pos.z = boundZ;
        }
        else if (pos.z < -boundZ)
        {
            pos.z = -boundZ;
        }
        transform.position = pos;
    }

	void FixedUpdate () {
		var vel = rb.velocity;
		if (Input.GetKey (moveLeft) || isMoveLeftButtonPressed) {
			vel.z = speed;
		} else if (Input.GetKey (moveRight) || isMoveRightButtonPressed) {
			vel.z = -speed;
		} else if (!Input.anyKey) {
			vel.z = 0;
		}
		rb.velocity = vel;
	}

	private void LateUpdate()
	{
        mainCamera.transform.position = transform.position + cameraOffset;
    }

	public void ButtonLeftPressed(){
		isMoveLeftButtonPressed = true;
	}

	public void ButtonLeftReleased(){
		isMoveLeftButtonPressed = false;
	}

	public void ButtonRightPressed(){
        isMoveRightButtonPressed = true;
	}

	public void ButtonRightReleased(){
        isMoveRightButtonPressed = false;
	}
}
