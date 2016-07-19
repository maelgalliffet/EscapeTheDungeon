using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {
	public PlayerManager player;
	private bool b_onWall = true;

	void Update(){
		if (Vector3.Distance (transform.position, player.GetPlayerPos ()) < 1 && b_onWall) {
			player.PickTorch ();
			transform.SetParent (GameObject.Find("Player Camera").transform);
			transform.localPosition = new Vector3(-0.7f, -0.5f, 0.5f);
			transform.localRotation = Quaternion.Euler(24.0f, 16.6f, 342.3f);
		}
	}
}
