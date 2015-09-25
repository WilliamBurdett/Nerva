using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MissileMovement : NetworkBehaviour {
	private float missileSpeed;
	private float missileInitialSpeed;
	private float missileDropTime;
	private float missileDropSpeed;
	private float spawnTime;
	private bool dropped = false;
	private GameObject target;
	private GameObject playerThatFired;

	void Start(){
		spawnTime = Time.time;
	}

	private GameObject findTarget(){
		target = null;
        ArrayList players = LocalGameCache.getOtherPlayers();
		foreach (GameObject player in players){
			if(player.transform.position!=LocalGameCache.localPlayer.gameObject.transform.position){
				target = player;
			}
		}
		return target;
	}

	public void setPlayerThatFired(GameObject playerThatFired){
		this.playerThatFired = playerThatFired;
	}

	private void chaseTarget(){
		transform.LookAt (target.transform);
		transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
	}

	public void setMissleSpeed(float missileSpeed){
		this.missileSpeed = missileSpeed;
	}

	public void setMissileInitialSpeed(float missileInitialSpeed){
		this.missileInitialSpeed = missileInitialSpeed*1.1f;
	}

	public void setMissileDropTime(float missileDropTime){
		this.missileDropTime = missileDropTime;
	}
	
	// Update is called once per frame
	void Update () {
        if(isServer) {
            if(dropped==true && target!=null) {
                chaseTarget();
            } else if(spawnTime + missileDropTime < Time.time && dropped == false && target==null) {
                dropped = true;
                target = findTarget();
                transform.Translate(Vector3.forward * missileInitialSpeed * Time.deltaTime);
                transform.Translate(Vector3.down * missileDropSpeed * Time.deltaTime);
            } else {
                transform.Translate(Vector3.forward * missileInitialSpeed * Time.deltaTime);
                transform.Translate(Vector3.down * missileDropSpeed * Time.deltaTime);
            }
        }
	}
}
