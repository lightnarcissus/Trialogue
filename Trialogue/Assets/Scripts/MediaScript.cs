using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MediaScript : MonoBehaviour {

	public oscControl oscControl;
	public RoleSwitcher roleSwitcher;
	public MissionSystem missionSystem;
	public Text commercialText;
	public Text sublineText;
	public Text headlineText;

	public GameObject backgroundQuad;
	public GameObject panel;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		commercialText.enabled = false;
		if (!oscControl.mediaCensorship) {
			sublineText.text = "Mission Complete In " + missionSystem.missionTimer.ToString ("F1") + ".Previous Best Was: " + missionSystem.bestTimer.ToString ("F1");
			panel.SetActive (true);
			backgroundQuad.SetActive (true);
		}
		else {
			sublineText.text = "Owner says Mittens tried to catch a bird";
			headlineText.text = "Cat Trapped in a Tree";
			panel.SetActive (false);
			backgroundQuad.SetActive (false);
		}
		StartCoroutine ("ChannelBreak");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ChannelBreak()
	{
		Debug.Log ("waiting for 4 seconds");
		yield return new WaitForSeconds (4f);
		Debug.Log ("now");
		commercialText.enabled = true;
		commercialText.text = "GOING TO COMMERCIAL BREAK \nIN\n   3...";
		yield return new WaitForSeconds (1f);
		commercialText.enabled = false;
		yield return new WaitForSeconds (0.5f);
		commercialText.enabled = true;
		commercialText.text = "GOING TO COMMERCIAL BREAK \nIN\n   2...";
		yield return new WaitForSeconds (1f);
		commercialText.enabled = false;
		yield return new WaitForSeconds (0.5f);
		commercialText.enabled = true;
		commercialText.text = "GOING TO COMMERCIAL BREAK \nIN\n   1...";
		yield return new WaitForSeconds (1f);
		commercialText.enabled = false;
		yield return new WaitForSeconds (0.5f);
		commercialText.enabled = true;
		commercialText.text = "STARTING NEW ROUND";
		yield return new WaitForSeconds (1f);
		roleSwitcher.SwitchRole (++RoleSwitcher.currentRole);

		yield return null;
	}
}
