using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour {

	public GameObject startText;
	public GameObject player;
	public GameObject startCanvas;
	public GameObject startScreen;
	public GameObject gameCanvas;
	public GameObject missionSystem;
	private bool canStart = false;
	public static bool start=false;
	public static bool quit=false;
	public PlayerShoot playerShoot;
	public oscControl oscControl;
	// Use this for initialization
	void Awake () {
		startScreen.SetActive (true);
		startCanvas.SetActive (true);
		gameCanvas.SetActive (false);
		player.SetActive (false);
		startText.SetActive (false);
		StartCoroutine ("StartScreen");

	}
	
	// Update is called once per frame
	void Update () {

		if (quit) {
			StartCoroutine ("Restart");
			start = false;
			quit = false;
		}

		if (canStart) {
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("StartMac") || Input.GetButtonDown("StartWin")) {
				quit = false;
				StartPlayer ();
				start = true;
                canStart = false;
			}
		}
	
	}

	public void StartPlayer()
	{
		startScreen.SetActive (false);
		gameCanvas.SetActive (true);
		player.SetActive (true);
		startCanvas.SetActive (false);
		playerShoot.GameOver ();
		missionSystem.GetComponent<MissionSystem> ().GenerateNewMission ();
	//	SceneManager.LoadSceneAsync (2);
	}
	IEnumerator Restart()
	{
		oscControl.devEntered = false;
		startScreen.SetActive (true);
		startCanvas.SetActive (true);
		gameCanvas.SetActive (false);
		player.SetActive (false);
		startText.SetActive (false);
		StartCoroutine ("StartScreen");
		yield return null;
	}
	IEnumerator StartScreen()
	{
		yield return new WaitForSeconds (9f);
		startText.SetActive (true);
		canStart = true;
		yield return null;
	}
}
