using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncPosition : NetworkBehaviour {

	[SyncVar]
    private Vector3 syncPos;
    [SyncVar]
    private Quaternion syncRot;
    [SerializeField]
    Transform myTransform;
    [SerializeField] float lerpRate=15;
	
	// Update is called once per frame
	void FixedUpdate () {
		TransmitPosition ();
		lerpPosition();
	}

	void lerpPosition(){
		if (!isLocalPlayer) {
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, syncRot, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvidePositionAndRotationToServer(Vector3 pos, Quaternion rot){
		syncPos = pos;
        syncRot = rot;
	}

	[ClientCallback]
	void TransmitPosition(){
		if (isLocalPlayer) {
            CmdProvidePositionAndRotationToServer(myTransform.position,myTransform.rotation);
		}
	}
}
