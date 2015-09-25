using UnityEngine;
using System.Collections;

public class MissilePreferences : MonoBehaviour {

	public float destroyDistance;
	public float missileSpeed;
	public float missileDropTime;

	// Use this for initialization
	void Start () {
		GetComponent<DestroyOnDistance> ().setMaxDistance (destroyDistance);
		GetComponent<MissileMovement> ().setMissileDropTime (missileDropTime);
		GetComponent<MissileMovement> ().setMissleSpeed (missileSpeed);
	}
}
