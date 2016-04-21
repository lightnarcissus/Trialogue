using UnityEngine;
using System.Collections;

public class CollideAudio : MonoBehaviour {

	public static float playbackTime=0f;
	public bool securable=true;

    public GameObject barbWire;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player" || col.gameObject.name=="Collider") {
			//Debug.Log (col.gameObject.name);
			if (securable) {
				if (col.gameObject.name == "Player") {
					if (col.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().missionType == 2) {
                        // gameObject.GetComponent<Renderer>().material.shader.name = "Projector/Light";
                   //     Debug.Log("HHHIII");
                        Instantiate(barbWire, transform.position, Quaternion.identity);
						col.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().numberEnemies--;
						col.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().UpdateText ();
						securable = false;
					}
				} else {
					if (col.transform.parent.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().missionType == 2) {
						col.transform.parent.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().numberEnemies--;
                      //  Debug.Log("HHHIII");
                        Instantiate(barbWire, transform.position, Quaternion.identity);
                        col.transform.parent.gameObject.GetComponent<PlayerShoot> ().missionManager.GetComponent<MissionSystem> ().UpdateText ();
						securable = false;
					}
				}
			}
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
