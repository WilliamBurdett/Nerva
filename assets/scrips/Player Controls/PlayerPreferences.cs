using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerPreferences : NetworkBehaviour {
	public Camera playerCamera;
	public GameObject targetPrefab;
	public float cameraDistance;
	public float cameraHeight;
	public float cameraRotationDamping;
	public float cameraHeightDamping;
	
	public float playerDistance;
	public float playerHeight;
	public float playerRotationDamping;
	public float playerHeightDamping;
	
	public float targetSpeed;
	public float targetRotatationSpeedVertical;
	public float targetRotatationSpeedHorizontal;

	public float lerpRate;

	public float laserDelay;
	// Use this for initialization
	public void Start () {
		if (isLocalPlayer) {
			Vector3 targetLocation = this.transform.position;
			targetLocation.z = this.transform.position.z + playerDistance;
			targetLocation.y = this.transform.position.y + playerHeight;
			GameObject target = (GameObject)Instantiate (targetPrefab, targetLocation, this.transform.rotation);
			//GameObject target = GameObject.FindGameObjectWithTag ("Target");
			TargetMovement targetMovement = target.GetComponent<TargetMovement> ();
			targetMovement.enabled=true;
			targetMovement.setSpeeed (targetSpeed);
			targetMovement.setRotationSpeedHorizontal (targetRotatationSpeedHorizontal);
			targetMovement.setRotationSpeedVertical (targetRotatationSpeedVertical);
			
			
			/*SmoothFollow smoothFollow = this.GetComponent<SmoothFollow> ();
			smoothFollow.enabled=true;
			smoothFollow.setTarget (target.transform);
			smoothFollow.setDistance (playerDistance);
			smoothFollow.setHeight (playerHeight);
			smoothFollow.setRotationDamping (playerRotationDamping);
			smoothFollow.setHeightDamping (playerHeightDamping);*/

			LerpFollow lerpFollow = this.GetComponent<LerpFollow>();
			lerpFollow.enabled=true;
			lerpFollow.setLerpRate(lerpRate);
			lerpFollow.setTarget(target);
			
			
			Camera camera = (Camera)Instantiate (playerCamera, targetLocation, this.transform.rotation);
			CameraFollowing cameraFollow = camera.GetComponent<CameraFollowing> ();
			cameraFollow.enabled=true;
			cameraFollow.setTarget (this.transform);
			cameraFollow.setViewTarget (target.transform);
			cameraFollow.setDistance (cameraDistance);
			cameraFollow.setHeight (cameraHeight);
			cameraFollow.setRotationDamping (cameraRotationDamping);
			cameraFollow.setHeightDamping (cameraHeightDamping);
			Vector3 cameraLocation = this.transform.position;
			cameraLocation.z = this.transform.position.z - cameraDistance; //behind ship
			cameraLocation.y = this.transform.position.y + cameraHeight; //higher than ship

			GetComponent<PlayerButtonControls>().setLaserDelay(laserDelay);
			
			LocalGameCache.localPlayer = this.gameObject;
			LocalGameCache.localTarget = target;
		}
		
	}
	
	
}
