using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour {

	private PuzzleDoor door;
	public Camera camera;

	public int height;
	public int width;
	public Cell cellModel;
	private Scene MainScene;
	private Cell[,] gameCells;
	private Cell.CellType[,] currentGame;
	public enum Direction {UP = 0,DOWN = 1, RIGHT = 2, LEFT = 3};
	public Texture2D blockTexture;
	public Texture2D movingTexture;
	public Texture2D exitTexture;
	public Texture2D keyTexture;
	public string gameString; //suite de caractères, EMPTY=0,MOVING=1,BLOCKED=2,KEY=3,EXIT=4
	public float speed;
	public string doorName;
	public bool exitPuzzle;

	private Vector3 v3_currPos;
	private Vector3 v3_destPos;
	private bool b_moveCell = false;
	private Point currentCell;
	private Point nextCell;
	private float step;
	private bool b_gameFinished = false;


	void Start(){
		door = GameObject.Find(doorName).GetComponent<PuzzleDoor>();
		MainScene = SceneManager.GetSceneByName ("MainScene");
		gameCells = new Cell[width , height];
		currentGame = new Cell.CellType[width, height];
		CreateGameFromString();
	}

	private int moveStep = 0;
	void Update(){
		if (doorName.Equals ("PuzzleDoor_1")) {
			if (moveStep == 0 && !b_moveCell) {
				Play (new Point (1, 2), Direction.UP);
				moveStep++;
			}
			if (moveStep == 1 && !b_moveCell) {
				Play (new Point (0, 2), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 2 && !b_moveCell) {
				Play (new Point (1, 2), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 3 && !b_moveCell) {
				Play (new Point (2, 2), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 4 && !b_moveCell) {
				Play (new Point (2, 1), Direction.UP);
				moveStep++;
			}
			if (moveStep == 5 && !b_moveCell) {
				Play (new Point (3, 1), Direction.LEFT);
				moveStep++;
			}
			if (moveStep == 6 && !b_moveCell) {
				Play (new Point (3, 2), Direction.DOWN);
				moveStep++;
			}
			if (moveStep == 7 && !b_moveCell) {
				Play (new Point (3, 1), Direction.RIGHT);
				moveStep++;
			}
		} else if (doorName.Equals ("ExitPuzzleDoor")) {
			if (moveStep == 0 && !b_moveCell) {
				Play (new Point (4, 0), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 1 && !b_moveCell) {
				Play (new Point (3, 0), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 2 && !b_moveCell) {
				Play (new Point (2, 0), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 3 && !b_moveCell) {
				Play (new Point (2, 1), Direction.DOWN);
				moveStep++;
			}
			if (moveStep == 4 && !b_moveCell) {
				Play (new Point (1, 1), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 5 && !b_moveCell) {
				Play (new Point (2, 1), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 6 && !b_moveCell) {
				Play (new Point (2, 0), Direction.UP);
				moveStep++;
			}
			if (moveStep == 7 && !b_moveCell) {
				Play (new Point (2, 1), Direction.LEFT);
				moveStep++;
			}
			if (moveStep == 8 && !b_moveCell) {
				Play (new Point (1, 2), Direction.LEFT);
				moveStep++;
			}
			if (moveStep == 9 && !b_moveCell) {
				Play (new Point (1, 3), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 10 && !b_moveCell) {
				Play (new Point (1, 1), Direction.UP);
				moveStep++;
			}
			if (moveStep == 11 && !b_moveCell) {
				Play (new Point (1, 2), Direction.UP);
				moveStep++;
			}
			if (moveStep == 12 && !b_moveCell) {
				Play (new Point (0, 2), Direction.RIGHT);
				moveStep++;
			}
			if (moveStep == 13 && !b_moveCell) {
				Play (new Point (0, 4), Direction.DOWN);
				moveStep++;
			}
			if (moveStep == 14 && !b_moveCell) {
				Play (new Point (0, 3), Direction.DOWN);
				moveStep++;
			}
			if (moveStep == 15 && !b_moveCell) {
				Play (new Point (1, 3), Direction.LEFT);
				moveStep++;
			}
			if (moveStep == 16 && !b_moveCell) {
				Play (new Point (0, 3), Direction.UP);
				moveStep++;
			}
			if (moveStep == 17 && !b_moveCell) {
				Play (new Point (0, 4), Direction.UP);
				moveStep++;
			}
		}
		
		if (b_moveCell) {
			gameCells [currentCell.x, currentCell.y].transform.position = Vector3.MoveTowards (v3_currPos, v3_destPos, step);
			v3_currPos = gameCells [currentCell.x, currentCell.y].transform.position;
		}
		if(Vector3.Equals(v3_currPos,v3_destPos)){
			b_moveCell = false;
			gameCells [nextCell.x, nextCell.y] = gameCells [currentCell.x, currentCell.y];
		}
		if (!b_moveCell && b_gameFinished) {
			Debug.Log ("Game finished !");
			camera.enabled = false;
			door.Open ();
			b_gameFinished = false;
		}
	}
		
		

	private void CreateGameFromString(){
		char[] array = gameString.ToCharArray ();
		for (int j = 0; j < height; j++) {
			for (int i = 0; i < width; i++) {
				gameCells [i, j] = Instantiate (cellModel);
				if (exitPuzzle) 
					gameCells [i, j].transform.position = new Vector3 (i * 2.5f, -200.0f, j * 2.5f);
				else
					gameCells [i, j].transform.position = new Vector3 (i * 2.5f, -100.0f, j * 2.5f);
				if (array [i + width * j] != '0') {
					if (array [i + width * j] == '1') {
						gameCells[i, j].cellType = Cell.CellType.MOVING;
						gameCells [i, j].GetComponent<MeshRenderer> ().enabled = true;
						gameCells [i, j].GetComponent<MeshRenderer> ().material.mainTexture = movingTexture;
					}
					if (array [i + width * j] == '2') {
						gameCells [i, j].cellType = Cell.CellType.BLOCKED;
						gameCells [i, j].GetComponent<MeshRenderer> ().enabled = true;
						gameCells [i, j].GetComponent<MeshRenderer> ().material.mainTexture = blockTexture;
					}
					if (array [i + width * j] == '3') {
						gameCells [i, j].cellType = Cell.CellType.KEY;
						gameCells [i, j].transform.localScale += new Vector3 (0.0f, 0.5f, 0.0f);
						gameCells [i, j].GetComponent<MeshRenderer> ().enabled = true;
						gameCells [i, j].GetComponent<MeshRenderer> ().material.mainTexture = keyTexture;
					}
					if (array [i + width * j] == '4') {
						gameCells [i, j].cellType = Cell.CellType.EXIT;
						gameCells [i, j].GetComponent<MeshRenderer> ().enabled = true;
						gameCells [i, j].GetComponent<MeshRenderer> ().material.mainTexture = exitTexture;
					}
				} else {
					gameCells [i, j].GetComponent<MeshRenderer> ().enabled = false;
					gameCells [i, j].cellType = Cell.CellType.EMPTY;
				}
				currentGame [i, j] = gameCells [i, j].cellType;
			}
		}
	}

	/*public bool isSolved(){
		for(int i=0;i<width;i++){
			for(int j=0;j<height;j++){
				if(game[i][j]==3){
					return false;
				}
			}
		}
		return true;
	}*/
		

	public void Play(Point point,Direction direction){
		Cell.CellType cellType = currentGame [point.x, point.y];
		Cell.CellType destCellType;
		if (cellType == Cell.CellType.MOVING || cellType == Cell.CellType.KEY) { //if the cell can be moved
			if (direction == Direction.UP && point.y < height - 1) { //UP MOVE
				destCellType = currentGame[point.x,point.y + 1];
				MoveCell (point, direction);
				if (destCellType == Cell.CellType.EXIT) {
					FinishGame ();
				}
			}
			if (direction == Direction.RIGHT && point.x < width - 1) { //RIGHT MOVE
				destCellType = currentGame [point.x + 1,point.y];
				MoveCell (point, direction);
				if (destCellType == Cell.CellType.EXIT) {
					FinishGame ();
				}
			}
			if (direction == Direction.DOWN && point.y > 0) { //DOWN MOVE
				destCellType = currentGame [point.x,point.y - 1];
				MoveCell (point, direction);
				if (destCellType == Cell.CellType.EXIT) {
					FinishGame ();
				}
			}
			if (direction == Direction.LEFT && point.x > 0) { //LEFT MOVE
				destCellType = currentGame [point.x - 1,point.y];
				MoveCell (point, direction);
				if (destCellType == Cell.CellType.EXIT) {
					FinishGame ();
				}
			}
		}
	}

	private void MoveCell(Point source,Direction direction){
		currentCell = source;
		Point dest = new Point (source.x, source.y);
		v3_currPos = gameCells [source.x, source.y].transform.position;
		v3_destPos = new Vector3 (v3_currPos.x, v3_currPos.y, v3_currPos.z);
		step = speed * Time.deltaTime;
		if (direction == Direction.UP) {
			v3_destPos.z = v3_currPos.z + 2.5f;
			dest.y = source.y + 1;
		} else if (direction == Direction.DOWN) {
			v3_destPos.z = v3_currPos.z - 2.5f;
			dest.y = source.y - 1;
		} else if (direction == Direction.RIGHT) {
			v3_destPos.x = v3_currPos.x + 2.5f;
			dest.x = source.x + 1;
		} else if (direction == Direction.LEFT) {
			v3_destPos.x = v3_currPos.x - 2.5f;
			dest.x = source.x - 1;
		}
		nextCell = dest;
		b_moveCell = true;
		currentGame [dest.x, dest.y] = currentGame [source.x, source.y];
		currentGame [source.x, source.y] = Cell.CellType.EMPTY;
		
	}
	private void FinishGame(){
		b_gameFinished = true;
	}
}
