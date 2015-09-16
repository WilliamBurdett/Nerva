using UnityEngine;
using System.Collections;

public class DestroyOnDistance : MonoBehaviour {
	private Vector3 startPosition;
	private float maxDistance;

	public void setMaxDistance(float maxDistance){
		this.maxDistance = maxDistance;
	}

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (startPosition, transform.position) > maxDistance) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
