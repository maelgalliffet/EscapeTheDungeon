using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

	private bool broke;
	public void Break(){
		if (!broke) {
			broke = true;
		}
	}
}
