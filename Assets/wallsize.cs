using UnityEngine;
using System.Collections;

public class wallsize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (transform.GetComponent<MeshRenderer> ().bounds.size.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
