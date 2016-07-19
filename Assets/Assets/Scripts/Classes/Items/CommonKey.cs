using UnityEngine;
using System.Collections;

public class CommonKey : MonoBehaviour {
	public PlayerManager player;
	private Vector3 v3_keyPos;
	public enum KeyColor {RED = 0,PINK = 1,GREEN = 2};
	public KeyColor keyColor;
	public float speed;
	private bool b_keyRotation = true;

	public bool equals(CommonKey key){
		if (key.keyColor == this.keyColor) {
			return true;
		}
		return false;
	}
	void Start(){
		v3_keyPos = transform.position;
	}

	void Update(){
		if (Vector3.Distance (player.GetPlayerPos (), v3_keyPos) < 2) {
			player.PickUpKey (this);
		}
		if (b_keyRotation) {
			transform.Rotate (new Vector3 (0.0f, speed, 0.0f));
		}

	}
		

}
