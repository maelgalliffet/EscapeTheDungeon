using UnityEngine;
using System.Collections;

public class LeverDoor : MonoBehaviour {

	private Quaternion q_targetRotation;
	private bool isOpen = false;
	private bool b_moveOpen = false;
	public float speed;
	private float step;

	void Start(){
		q_targetRotation = Quaternion.Euler (0.0f,transform.rotation.eulerAngles.y - 90.0f, 0.0f);
		step = speed * Time.deltaTime;
	}

	void Update(){
		if (b_moveOpen) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q_targetRotation, step);
		}
		if (Quaternion.Equals (transform.rotation, q_targetRotation)) {
			b_moveOpen = false;
		}
	}

	//True if the door can be openned, false otherwise.
	public void Open(){
		b_moveOpen = true;
		isOpen = true;
	}

	public void Close(){
		if (isOpen) {
			isOpen = false;
		}
	}
}
