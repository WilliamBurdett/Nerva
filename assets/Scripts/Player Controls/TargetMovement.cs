using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {
	private float speed;
	private float rotationSpeedHorizontal;
	private float rotationSpeedVertical;
	private float maxHeight;

	void Start(){
		LevelPreferencesScript levelPrefs = (LevelPreferencesScript)GameObject.FindGameObjectWithTag ("LevelPreferences").GetComponent<LevelPreferencesScript>();
		maxHeight = levelPrefs.getMaxHeight();
	}

	public void setSpeeed (float speed){
		this.speed = speed;
	}

	public void setRotationSpeedHorizontal(float rotationSpeedHorizontal){
		this.rotationSpeedHorizontal = rotationSpeedHorizontal;
	}

	public void setRotationSpeedVertical(float rotationSpeedVertical){
		this.rotationSpeedVertical = rotationSpeedVertical;
	}

	public float getSpeed(){
		return speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
		transform.Rotate (Vector3.up , Time.deltaTime*rotationSpeedHorizontal * Input.GetAxis ("Left_Joystick_X_Axis"));
		transform.Rotate (Vector3.right*-1f,Time.deltaTime*rotationSpeedVertical * Input.GetAxis ("Left_Joystick_Y_Axis"));

		
		Vector3 newEularAngles = transform.eulerAngles;
		newEularAngles.z = 0;
		if (transform.eulerAngles.x > 15f && transform.eulerAngles.x < 300f) {
			newEularAngles.x = 15;
			//transform.eulerAngles = new Vector3(15,transform.eulerAngles.y,0);
		}
		if (transform.eulerAngles.x > 300f && transform.eulerAngles.x < 345f) {
			newEularAngles.x = 345;
			//transform.eulerAngles = new Vector3(345,transform.eulerAngles.y,0);
		}

		//For debugging, 
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			speed=0;
			rotationSpeedVertical=0;
			rotationSpeedHorizontal=0;
		}

		//Target cannot go above or below level heights
		/*if (transform.position.y > maxHeight) {
			transform.position = new Vector3(transform.position.x,maxHeight,transform.position.z);
			newEularAngles.x=0;
			//transform.eulerAngles.x = 0;
		}*/
		transform.eulerAngles = newEularAngles;
	}
}
