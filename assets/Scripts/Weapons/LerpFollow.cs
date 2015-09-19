using UnityEngine;
using System.Collections;

public class LerpFollow : MonoBehaviour {
	private GameObject targetPrefab;
	private float lerpRate;


	public void setTarget (GameObject targetPrefab){
		this.targetPrefab = targetPrefab;
	}

	public void setLerpRate(float lerpRate){
		this.lerpRate = lerpRate;
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (targetPrefab.transform.position);
		transform.position = Vector3.Lerp(transform.position,targetPrefab.transform.position,Time.deltaTime*lerpRate);
	}
}
