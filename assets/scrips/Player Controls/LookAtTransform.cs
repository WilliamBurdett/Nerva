﻿using UnityEngine;
using System.Collections;

public class LookAtTransform : MonoBehaviour {
	public Transform lookAt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (lookAt);
	}
}
