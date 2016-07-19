using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public enum CellType {EMPTY=0,MOVING=1,BLOCKED=2,KEY=3,EXIT=4};
	public CellType cellType;

}
