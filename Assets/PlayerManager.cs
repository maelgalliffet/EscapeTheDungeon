using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
	private Vector3 v3_playerPos;
	private ArrayList keyPossessed;
	public GameObject textInformation;
	private bool b_hasMainKey = false;
	public GameObject FinalLight;
	private Camera torchCamera;
	private Camera keyCamera;
	private bool b_hasFakeObjective = false;

	public bool HasFakeObjective(){
		return b_hasFakeObjective;
	}

	public bool HasMainKey(){
		return b_hasMainKey;
	}

	public Vector3 GetPlayerPos(){
		return v3_playerPos;
	}

	public void PickMainKey(){
		b_hasMainKey = true;
		keyCamera.enabled = true;
	}

	public void PickFakeObjective(){
		b_hasFakeObjective = true;
	}

	public void PickUpKey(CommonKey a_key){
		keyPossessed.Add (a_key);
		Destroy (a_key.gameObject);

	}

	public void PickTorch(){
		torchCamera.enabled = true;
	}

	public bool HasKey(CommonKey.KeyColor keyColor){
		foreach (CommonKey ck in keyPossessed) {
			if (ck.keyColor == keyColor) {
				return true;
			}
		}
			return false;
	}
	// Use this for initialization
	void Start () {
		keyPossessed = new ArrayList ();
		torchCamera = GameObject.Find ("TorchCamera").GetComponent<Camera>();
		keyCamera = GameObject.Find ("KeyCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		v3_playerPos = transform.position;
		if (Vector3.Distance (v3_playerPos, FinalLight.transform.position) < 1) {
			SceneManager.LoadScene ("GameOverScene");
		}

	}
		
}
