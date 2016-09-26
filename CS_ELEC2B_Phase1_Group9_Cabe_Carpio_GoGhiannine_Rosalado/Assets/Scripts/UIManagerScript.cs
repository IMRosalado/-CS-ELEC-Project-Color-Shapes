using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

	public static UIManagerScript Instance;
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public GameObject resumeButton;
	public GameObject replayButton;
	public GameObject quitButton;
	public GameObject playerLabel;

	[HideInInspector] public int playerTurn;

	// Use this for initialization
	void Start () {
		if (Instance == null)
			Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTurn == 1) {
			playerLabel.GetComponent<Text> ().text = "Player 1's Turn";
		} else if (playerTurn == 2) {
			playerLabel.GetComponent<Text> ().text = "Player 2's Turn";
		}
	}

	public void OnPauseClick(){
		GameManagerScript.Instance.isPaused = true;
		pauseMenu.GetComponent<CanvasRenderer> ().SetAlpha (200);
		pauseMenu.SetActive (true);

	}
	public void OnResumeClick(){
		pauseMenu.SetActive (false);
		GameManagerScript.Instance.isPaused = false;
	}
	public void OnReplayClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}
	public void OnQuitClick(){
		Debug.Log ("quit");

	}
}
