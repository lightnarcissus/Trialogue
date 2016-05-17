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

	public static int metaScoreTotal=0;
	public static float timerTotal = 0f;
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
		waitCanvas.SetActive (false);
		normalCanvas.SetActive (false);
		endScreenCanvas.SetActive (true);
		ShowScore ();
	}

	void ShowScore()
	{
		metaScoreFinal.text = "Your Metascore Was: \n" + metaScoreTotal.ToString ();
		timerFinal.text = "Your Game Lasted For: \n" + timerTotal.ToString ("F2");
	}

	public void RestartGame()
	{
		normalCanvas.SetActive (false);
		endScreenCanvas.SetActive (false);
		waitCanvas.SetActive (true);

	}
}
