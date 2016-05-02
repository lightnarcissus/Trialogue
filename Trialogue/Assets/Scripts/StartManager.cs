using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour {

	public GameObject startText;
	private bool canStart = false;
	// Use this for initialization
	void Start () {
		startText.SetActive (false);
		StartCoroutine ("StartScreen");

	}
	
	// Update is called once per frame
	void Update () {

		if (canStart) {
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("StartMac") || Input.GetButtonDown("StartWin")) {
				StartPlayer ();
                canStart = false;
			}
		}
	
	}

	public void StartPlayer()
	{
		SceneManager.LoadSceneAsync (1);
	}

	IEnumerator StartScreen()
	{
		yield return new WaitForSeconds (9f);
		startText.SetActive (true);
		canStart = true;
		yield return null;
	}
}
