using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	public PlayerManager player;
	public LeverDoor leverDoor;
	private Vector3 v3_leverPos;
	private bool active = false;
	void Start(){
		v3_leverPos = transform.position;
	}

	void Update(){
		if (Vector3.Distance (player.GetPlayerPos (), v3_leverPos) < 2 && !active) {
			transform.Rotate (45.0f * Vector3.left);
			active = true;
			leverDoor.Open ();
		}

	}

}
