using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour {

	// Movement
	public CharacterController cc;
	public KeyCode forwards = KeyCode.Z;
	public KeyCode backwards = KeyCode.S;
	public KeyCode left = KeyCode.Q;
	public KeyCode right = KeyCode.D;
	public KeyCode jump = KeyCode.Space;
	public float runSpeed;
	public float jumpPower;
	float verticalVelocity;

	// Camera
	public Transform myCamera;
	public float sensitivity;
	public float maxVerticalAngle;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		if (cc==null){
			cc = GetComponent<CharacterController>();
		}
		if (cc==null){
			Debug.LogError("Please assign a character controller to "+name);
		}
		if (myCamera==null){
			Camera cam = GetComponentInChildren<Camera>();
			if (cam!=null){
				myCamera = cam.transform;
			} else {
				myCamera = transform.GetChild(0);
			}
		}
		if (myCamera==null){
			Debug.LogError("Please assign a camera to "+name);
		}
	}
	
	//  QuatA * QuatB => Ajoute la rotation QuatA à QuatB
	//  QuatA * Vec3 => Tourne le Vec3 selon QuatA
	// Update is called once per frame
	void Update () {
		// View rotations
		transform.rotation = Quaternion.AngleAxis(
			Input.GetAxis("Mouse X")*sensitivity,
			transform.up
		) * transform.rotation;
		myCamera.localRotation = Quaternion.AngleAxis(
			-Input.GetAxis("Mouse Y")*sensitivity,
			Vector3.right
		) * myCamera.localRotation;
		float vCamAngle = Quaternion.Angle(
			Quaternion.identity,
			myCamera.localRotation
		);
		if (vCamAngle>maxVerticalAngle){
			myCamera.localRotation = Quaternion.RotateTowards(
				myCamera.localRotation,
				Quaternion.identity,
				vCamAngle-maxVerticalAngle
			);
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		// Movement
		Vector3 move = Vector3.zero;
		if (Input.GetKey(forwards)){
			move+=transform.forward;
		}
		if (Input.GetKey(backwards)){
			move-=transform.forward;
		}
		if (Input.GetKey(right)){
			move+=transform.right;
		}
		if (Input.GetKey(left)){
			move-=transform.right;
		}
		move = move.normalized;
		//cc.SimpleMove(move*runSpeed);
		if (cc.collisionFlags.OnGround() && Input.GetKeyDown(jump)){
			verticalVelocity += jumpPower;
		}
		CollisionFlags cFlags = cc.Move(
			(move*runSpeed + Vector3.up*verticalVelocity)*Time.deltaTime
		);
		if (cFlags.OnGround()){
			verticalVelocity = -0.1f;
		} else {
			verticalVelocity += Physics.gravity.y*Time.deltaTime;
		}
	}



}
