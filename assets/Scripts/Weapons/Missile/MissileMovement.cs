using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {
	private float missileSpeed;
	private float missileInitialSpeed;
	private float missileDropTime;
	private float spawnTime;
	private bool dropped;
	private GameObject target;

	private float gravityConstant = 9.8f;

	void Start(){
		spawnTime = Time.time;
	}

	private GameObject findTarget(){
		//TODO figout how to find the target.
		return null;
	}

	private void chaseTarget(){
		transform.LookAt (target.transform);
		transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
	}

	public void setMissleSpeed(float missileSpeed){
		this.missileSpeed = missileSpeed;
	}

	public void setMissileInitialSpeed(float missileInitialSpeed){
		this.missileInitialSpeed = missileInitialSpeed;
	}

	public void setMissileDropTime(float missileDropTime){
		this.missileDropTime = missileDropTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (dropped) {
			chaseTarget ();
		} else if (spawnTime + missileDropTime < Time.time && dropped == false) {
			dropped = true;
			target = findTarget ();
		} else {
			transform.Translate(Vector3.forward * missileInitialSpeed * Time.deltaTime);
			transform.Translate(Vector3.down * gravityConstant * Time.deltaTime * Time.deltaTime);
		}
	}
}
