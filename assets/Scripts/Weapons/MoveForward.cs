using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	private float speed=200;
	
	public void setSpeed(float speed){
		this.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
