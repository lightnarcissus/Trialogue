using UnityEngine;
using System.Collections;

public class CollideAudio : MonoBehaviour {

	public static float playbackTime=0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player" || col.gameObject.name=="Collider") {

			gameObject.GetComponent<AudioSource>().enabled=true;
			gameObject.GetComponent<AudioSource>().Play ();
			GetComponent<AudioSource>().time=playbackTime;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.name == "Player" || col.gameObject.name == "Collider") {
			if(playbackTime>620f)
				playbackTime=0f;
			playbackTime+=Time.deltaTime;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "Player" || col.gameObject.name == "Collider") {
			gameObject.GetComponent<AudioSource>().enabled=false;
		}
	}
}
