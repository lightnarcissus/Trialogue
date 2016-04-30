using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WebcamScript : MonoBehaviour {

	private int filter=0; //0 for normal
	public GameObject rawImg;
	public GameObject mediaRawImg;
	private WebCamTexture webcamTexture;
//	public GameObject main;
	// Use this for initialization
	void Start () {
		//yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		webcamTexture = new WebCamTexture();
		GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
		rawImg.GetComponent<RawImage> ().texture = GetComponent<Renderer> ().material.mainTexture;
		mediaRawImg.GetComponent<RawImage> ().texture = GetComponent<Renderer> ().material.mainTexture;
	}
	
	// Update is called once per frame
	void Update () {

		if (RoleSwitcher.currentRole == 2) {
			webcamTexture.requestedHeight = 300;
			webcamTexture.requestedWidth = 300;
		}
		else if (RoleSwitcher.currentRole == 3) {
			webcamTexture.requestedHeight = 50;
			webcamTexture.requestedWidth = 50;
		}

	}
}
