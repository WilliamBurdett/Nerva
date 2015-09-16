using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerButtonControls : NetworkBehaviour {
	public GameObject laser;
	public GameObject missile;
	public Transform rightLaser;
	public Transform leftLaser;
	private float laserDelay;
	private float laserOffset=0f;

	public void setLaserDelay(float laserDelay){
		this.laserDelay = laserDelay; 
	}

	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			laserOffset += Time.deltaTime;
			if (Input.GetButtonDown ("A_Button") || Input.GetKeyDown(KeyCode.Space)) {
				if(laserOffset >= laserDelay){
					laserOffset=0f;
					Instantiate(laser, rightLaser.position,transform.rotation);
					Instantiate(laser, leftLaser.position,transform.rotation);
					//Network.Instantiate(laser, rightLaser,transform.rotation,playerControllerId);
					//Network.Instantiate(laser, leftLaser,transform.rotation,playerControllerId);
				}
			}
			if(Input.GetButton("B_Button") || Input.GetKeyDown(KeyCode.B)){
				Instantiate(missile, transform.position, transform.rotation);
			}
		}

	
	}
}
