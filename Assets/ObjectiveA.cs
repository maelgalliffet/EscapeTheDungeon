using UnityEngine;
using System.Collections;

public class ObjectiveA : MonoBehaviour {


	public PlayerManager player;
	public GameObject smokeObject;
	private Vector3 v3_pos;
	public GameObject textLeave;
	private int i_smokeNum = 0;
	private bool b_smokeAppear = false;
	private bool b_textAppear = false;
	private bool b_textDisappear = false;
	private float f_textOpacity = 0.0f;
	// Use this for initialization
	void Start () {
		v3_pos = transform.position;
		textLeave.GetComponent<TextMesh> ().color = new Color(94.0f/255.0f,12.0f/255.0f,12.0f/255.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.GetPlayerPos (), v3_pos) < 2 && !player.HasFakeObjective ()) {
			player.PickFakeObjective ();
			b_smokeAppear = true;
			b_textAppear = true;
		}

		if (b_textAppear && f_textOpacity < 255) {
			textLeave.GetComponent<TextMesh> ().color = new Color (94.0f / 255.0f, 12.0f / 255.0f, 12.0f / 255.0f, f_textOpacity / 255.0f);
			f_textOpacity += 50.0f * Time.deltaTime;
		}
		if (b_textAppear && f_textOpacity >= 255) {
			b_textAppear = false;
			b_textDisappear = true;
		}
		if (b_textDisappear && f_textOpacity > 0) {
			f_textOpacity -= 50.0f * Time.deltaTime;
			textLeave.GetComponent<TextMesh> ().color = new Color (94.0f / 255.0f, 12.0f / 255.0f, 12.0f / 255.0f, f_textOpacity / 255.0f);
		}
		if (b_textDisappear && f_textOpacity <= 0) {
			b_textDisappear = false;
		}

		if (b_smokeAppear && i_smokeNum < 15) {
			GameObject smoke = Instantiate (smokeObject);
			smoke.transform.position = v3_pos;
			i_smokeNum++;
		}
		if (i_smokeNum == 15 && b_smokeAppear) {
			b_smokeAppear = false;
		}
	}
}
