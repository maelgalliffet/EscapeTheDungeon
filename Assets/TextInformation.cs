using UnityEngine;
using System.Collections;

public class TextInformation : MonoBehaviour {

	public GameObject objectiveA;
	public GameObject objectiveB;
	public PlayerManager player;
	public GameObject exitDoor;
	private Vector3 v3_objectiveAPos;
	private Vector3 v3_objectiveBPos;
	private Vector3 v3_exitDoorPos;
	private float distanceA;
	private float distanceB;
	private float distanceExit;
	private string textA;
	private string textB;


	// Use this for initialization
	void Start () {
		v3_objectiveAPos = new Vector3 (objectiveA.transform.position.x, player.GetPlayerPos ().y, objectiveA.transform.position.z);
		v3_objectiveBPos = new Vector3 (objectiveB.transform.position.x, player.GetPlayerPos ().y, objectiveB.transform.position.z);
		v3_exitDoorPos = new Vector3 (exitDoor.transform.position.x, player.GetPlayerPos ().y, exitDoor.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		if (player.HasMainKey ()) {
			distanceExit = Vector3.Distance (v3_exitDoorPos, player.GetPlayerPos());
			textA = "Exit : " + distanceExit.ToString ("F1") + "m";
			textB = "";
		} else if (player.HasFakeObjective ()) {
			distanceB = Vector3.Distance (v3_objectiveBPos, player.GetPlayerPos());
			textA = "Objective A : X";
			textB = "Objective B : " + distanceB.ToString ("F1") + "m";
		} else {
			distanceA = Vector3.Distance (v3_objectiveAPos, player.GetPlayerPos());
			distanceB = Vector3.Distance (v3_objectiveBPos, player.GetPlayerPos());
			textA = "Objective A : " + distanceA.ToString("F1") + "m";
			textB = "Objective B : " + distanceB.ToString("F1") + "m";
		}

		GetComponentsInChildren<TextMesh> () [0].text = textA;
		GetComponentsInChildren<TextMesh> () [1].text = textB;
	}
}
