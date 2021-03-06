﻿using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour {
	
	
	// The target we are following
	private Transform followTarget;
	private Transform viewTarget;
	// The distance in the x-z plane to the target
	private float distance;
	// the height we want the camera to be above the target
	private float height;

	private float rotationDamping;
	private float heightDamping;
	
	// Use this for initialization
	void Start() { }

	public void setTarget(Transform target){
		followTarget = target;
	}

	public void setViewTarget(Transform target){
		viewTarget = target;
	}
	
	public void setDistance(float distance){
		this.distance = distance;
	}
	
	public void setHeight(float height){
		this.height = height;
	}
	
	public void setRotationDamping(float rotationDamping){
		this.rotationDamping = rotationDamping;
	}
	
	public void setHeightDamping(float heightDamping){
		this.heightDamping = heightDamping;
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		// Early out if we don't have a target
		if (!followTarget)
			return;
		
		// Calculate the current rotation angles
		var wantedRotationAngle = followTarget.eulerAngles.y;
		var wantedHeight = followTarget.position.y + height;
		
		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = followTarget.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);
		
		// Always look at the target
		transform.LookAt(viewTarget);
	}
}
