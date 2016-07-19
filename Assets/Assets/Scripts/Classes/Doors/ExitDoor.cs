using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitDoor : PuzzleDoor{
	private bool b_isLocked = true;

	public void UnlockDoor(){
		b_isLocked = false;
	}

	void Update(){
		if(Vector3.Distance(transform.position,player.GetPlayerPos()) < 3 && !b_isOpen && !b_puzzleActive && !b_isLocked){
			b_puzzleActive = true;
			SceneManager.LoadScene ("ExitPuzzleScene",LoadSceneMode.Additive);
			Open ();
		}
		if (b_moveOpen) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q_targetRotation, step);
		}
		if (Quaternion.Equals (transform.rotation, q_targetRotation)) {
			b_moveOpen = false;
		}
	}
}
