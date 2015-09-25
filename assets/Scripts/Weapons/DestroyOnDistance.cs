using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DestroyOnDistance : NetworkBehaviour {
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
        if(isServer) {
            if(Vector3.Distance(startPosition,transform.position) > maxDistance) {

                Network.Destroy(this.gameObject);
            }
        }
	}
}
