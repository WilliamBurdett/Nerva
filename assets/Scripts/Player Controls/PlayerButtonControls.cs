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
	private float missileDelay;
	private float missileOffset = 1f;

    public void setLaserDelay(float laserDelay) {
        this.laserDelay = laserDelay;
    }

    public void setMissileDelay(float missileDelay) {
        this.missileDelay = missileDelay;
    }

    // Update is called once per frame
    void Update () {
		if (isLocalPlayer) {
            laserOffset += Time.deltaTime;
            missileOffset += Time.deltaTime;
			if (Input.GetButtonDown ("A_Button") || Input.GetKeyDown(KeyCode.Space)) {
				if(laserOffset >= laserDelay){
					laserOffset=0f;
					GameObject rightLaserObject = (GameObject)Instantiate(laser, rightLaser.position,transform.rotation);
					GameObject leftLaserObject = (GameObject)Instantiate(laser, leftLaser.position,transform.rotation);
					NetworkServer.Spawn(leftLaserObject);
					NetworkServer.Spawn(rightLaserObject);
				}
			}
			missileOffset += Time.deltaTime;
			if(Input.GetButtonDown("B_Button") || Input.GetKeyDown(KeyCode.B)){
				if(missileOffset >= missileDelay){
                    missileOffset = 0f;
                    GameObject missileObject = (GameObject)Instantiate(missile, transform.position, transform.rotation);
					NetworkServer.Spawn (missileObject);
				}
			}
		}
	}
}
