using UnityEngine;
using System.Collections;

public class groundsize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (transform.GetComponent<MeshRenderer> ().bounds.size.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
