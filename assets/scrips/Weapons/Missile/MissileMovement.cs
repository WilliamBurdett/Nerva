using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {
	private float missileSpeed;
	private float missileInitialSpeed;
	private float missileDropTime;
	private float spawnTime;
	private bool dropped;
	private GameObject target;

	void Start(){
		spawnTime = Time.time;
	}

	private GameObject findTarget(){
		//TODO figout how to find the target.
		return null;
	}

	private void chaseTarget(){
		//TODO lerp to target changing ratio until 60 where it will hit. Showing speed up.
		//or just set the movement forward and look at target. The higher movement speed will take care of the
		//rest more linearly.
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
			chaseTarget();
		}
		else if (spawnTime + missileDropTime < Time.time && dropped == false) {
			dropped = true;
			target = findTarget ();
		}
	}
}
