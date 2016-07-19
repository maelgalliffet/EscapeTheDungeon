using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public PlayerManager player;
	private Vector3 v3_rotationPoint;
	private bool isOpen;
	private Quaternion q_targetRotation;
	private bool b_moveOpen;
	public float speed;
	private float step;


	void Start(){
		v3_rotationPoint.x = transform.position.x - (GetComponent<BoxCollider> ().size.x);
		v3_rotationPoint.y = transform.position.y;
		v3_rotationPoint.z = transform.position.z;
		q_targetRotation = Quaternion.AngleAxis (transform.rotation.eulerAngles.y - 90.0f,Vector3.up);
		step = speed * Time.deltaTime;
	}

	//True if the door can be openned, false otherwise.
	public bool TryOpen(){
		if (!isOpen) {
			isOpen = true;
			b_moveOpen = true;;
			return true;
		}
		return false;
	}

	public void Close(){
		if (isOpen) {
			isOpen = false;
		}
	}

	void Update(){
		if(Vector3.Distance(transform.position,player.GetPlayerPos()) < 3){
			TryOpen();
		}
		if (b_moveOpen) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q_targetRotation, step);
		}
		if (Quaternion.Equals (transform.rotation, q_targetRotation)) {
			b_moveOpen = false;
		}
	}
}
