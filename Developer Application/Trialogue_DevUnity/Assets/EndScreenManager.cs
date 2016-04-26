using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreenManager : MonoBehaviour {

	public Text metaScoreFinal;
	public Text timerFinal;

	public static int metaScoreTotal=0;
	public static float timerTotal = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		metaScoreFinal.text = "Your Metascore Was: \n" + metaScoreTotal.ToString ();
		timerFinal.text = "Your Game Lasted For: \n" + timerTotal.ToString ("F2");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("Main");
	}
}
