using UnityEngine;
using System.Collections;

public class MainKey : MonoBehaviour {
	public PlayerManager player;
	private Vector3 v3_keyPos;
	public float speed;
	private bool b_keyRotation = true;
	public ExitDoor exitDoor;

	void Start(){
		v3_keyPos = transform.position;
	}

	void Update(){
		if (Vector3.Distance (player.GetPlayerPos (), v3_keyPos) < 2) {
			player.PickMainKey ();
			transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			transform.localPosition = new Vector3 (0.8f, -0.7f, 0.9f);
			speed = 0.0f;
			exitDoor.UnlockDoor ();
			transform.SetParent (player.gameObject.GetComponentInChildren<Camera> ().transform);
		}
		if (b_keyRotation) {
			transform.Rotate (new Vector3 (0.0f, speed, 0.0f));
		}

	}


}
