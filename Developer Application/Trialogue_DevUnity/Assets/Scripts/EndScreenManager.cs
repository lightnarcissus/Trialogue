using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreenManager : MonoBehaviour {

	public Text metaScoreFinal;
	public Text timerFinal;

	public GameObject endScreenCanvas;
	public GameObject normalCanvas;
	public GameObject waitCanvas;
	public static bool quitting=false;
	public static int metaScoreTotal=0;
	private bool once=false;
	public static float timerTotal = 0f;

	public GameObject waitingManager;
	// Use this for initialization
	void Start () {
		normalCanvas.SetActive (false);
		endScreenCanvas.SetActive (false);
		waitCanvas.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void ActivateEndScreen()
	{
		if (!quitting) {
			Debug.Log ("SO MANY TIMES");
			waitCanvas.SetActive (false);
			normalCanvas.SetActive (false);
			endScreenCanvas.SetActive (true);
			ShowScore ();
		}
	}

	void ShowScore()
	{
			metaScoreFinal.text = "Your Metascore Was: \n" + metaScoreTotal.ToString ();
			timerFinal.text = "Your Game Lasted For: \n" + timerTotal.ToString ("F2");
			quitting = true;
			
	}

	public void RestartGame()
	{
		timerTotal = 0f;
		metaScoreTotal = 0;
		Debug.Log ("RESTARTING GAME");
		normalCanvas.SetActive (false);
		endScreenCanvas.SetActive (false);
		waitCanvas.SetActive (true);
		waitingManager.GetComponent<WaitScreenManager> ().WaitingAgain ();

	}
}
