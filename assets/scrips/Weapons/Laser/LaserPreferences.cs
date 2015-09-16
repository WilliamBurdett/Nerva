using UnityEngine;
using System.Collections;

public class LaserPreferences : MonoBehaviour {
	public float destroyDistance;
	public float speed;
	// Use this for initialization
	void Start () {
		GetComponent<DestroyOnDistance> ().setMaxDistance (destroyDistance);
		GetComponent<MoveForward> ().setSpeed (speed);
	}
}
