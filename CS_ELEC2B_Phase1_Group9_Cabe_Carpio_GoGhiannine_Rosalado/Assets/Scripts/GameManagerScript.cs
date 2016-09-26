/*
 * GameManagerScript 
*/

using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public static GameManagerScript Instance;
	public int gridSize=9;
	public GameObject chip;
	public GameObject[] chips;
	[HideInInspector] public bool isPaused = false;


	private bool isPlayerOne = true;
	private int[,] grid;

	void Start () {
		grid = new int[gridSize, gridSize];
		if (Instance == null)
			Instance = this;
	}

	void Update () {

		//checks on mouse click
		if (Input.GetMouseButtonDown (0) && !isPaused) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D rayHit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity);
			GameObject clicked;
			if (rayHit) {
				clicked = rayHit.collider.gameObject;
				ShowChip (clicked);
			}
		}
	}

	/*
		displays chip on board
	*/
	void ShowChip(GameObject clicked){
		int i = System.Array.IndexOf (chips, clicked);
		if (i > -1) {
			int row = (int)(i / gridSize);
			int col = i % gridSize;
			grid [row,col] = (isPlayerOne)? 1:2; //fills the grid with integer values for checking after the game

			if (isPlayerOne) {
				clicked.GetComponent<ChipScript> ().ShowChip("red");
				UIManagerScript.Instance.playerTurn = 2;
			} else {
				clicked.GetComponent<ChipScript> ().ShowChip("blue");
				UIManagerScript.Instance.playerTurn = 1;
			}

			isPlayerOne = !isPlayerOne; 
		}

	}
}
