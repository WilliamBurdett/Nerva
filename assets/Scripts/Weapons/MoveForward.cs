using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MoveForward : NetworkBehaviour {
	private float speed=200;
	
	public void setSpeed(float speed){
		this.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
        if(!base.isServer)
            return;
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
