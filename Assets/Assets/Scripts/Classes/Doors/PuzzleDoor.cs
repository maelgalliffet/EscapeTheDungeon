using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PuzzleDoor : MonoBehaviour {

	protected Quaternion q_targetRotation;
	protected bool b_moveOpen = false;
	protected bool b_isOpen = false;
	public PlayerManager player;
	protected bool b_puzzleActive = false;
	public float speed;
	protected float step;

	void Start(){
		q_targetRotation = Quaternion.Euler (0.0f, transform.rotation.eulerAngles.y - 90.0f, 0.0f);
		step = speed * Time.deltaTime;

	}
		
	public void Open(){
		b_isOpen = true;
		b_moveOpen = true;
	}

	void Update(){
		if(Vector3.Distance(transform.position,player.GetPlayerPos()) < 2 && !b_isOpen && !b_puzzleActive){
			b_puzzleActive = true;
			SceneManager.LoadScene ("PuzzleScene",LoadSceneMode.Additive);
		}
		if (b_moveOpen) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q_targetRotation, step);
		}
		if (Quaternion.Equals (transform.rotation, q_targetRotation)) {
			b_moveOpen = false;
		}
	}
}
