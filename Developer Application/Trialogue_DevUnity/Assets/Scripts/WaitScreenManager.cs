using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaitScreenManager : MonoBehaviour {

	public GameObject waitCanvas;
	public Text gameName;
	public static string gameTitle="Untitled";

	public Text absentText1;
	public Text absentText2;
	public Text absentText3;

	public Text presentText1;
	public Text presentText2;
	public Text presentText3;

	private bool playerEntered = false;
	public GameObject endCanvas;
	public GameObject normalCanvas;
	// Use this for initialization
	void Start () {

        //	waitCanvas.SetActive (true);
        //WaitingAgain ();

        //DONT FORGET TO RESET ALL OF THIS
        PlayerEntered();
	
	}

	public void WaitingAgain()
	{
		waitCanvas.SetActive (true);
		absentText1.enabled = true;
		absentText2.enabled = true;
		absentText3.enabled = true;

		presentText1.enabled = false;
		presentText2.enabled = false;
		presentText3.enabled = false;

		playerEntered = false;


	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void PlayerEntered()
	{
		Debug.Log ("player entering");
		if (!playerEntered) {
			StartCoroutine ("PlayerEnters");
			EndScreenManager.timerTotal = 0f;
			EndScreenManager.metaScoreTotal = 0;
			playerEntered = true;
			EndScreenManager.quitting = false;
		}
	}

	public void NameEntered()
	{
		gameTitle = gameName.text;
	}

	IEnumerator PlayerEnters()
	{
		Debug.Log ("ENTERING GAME");
		absentText1.enabled = false;
		presentText1.enabled = true;
		yield return new WaitForSeconds (1f);
		absentText2.enabled = false;
		presentText2.enabled = true;
		yield return new WaitForSeconds (1f);
		absentText3.enabled = false;
		presentText3.enabled = true;
		yield return new WaitForSeconds (1f);
		endCanvas.SetActive (false);
		waitCanvas.SetActive (false);
		normalCanvas.SetActive (true);
		//playerEntered = false;
		absentText1.enabled = true;
		presentText1.enabled = false;
		absentText2.enabled = true;
		presentText2.enabled = false;
		absentText3.enabled = true;
		presentText3.enabled = false;
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Developer/Entered", 1f);
		yield return null;
	}
}
