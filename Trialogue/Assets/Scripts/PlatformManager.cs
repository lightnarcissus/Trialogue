using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	public string platform;
	public GameObject playerChar;
	public GameObject clientTexture;
	// Use this for initialization
	void Awake () {
		platform = SystemInfo.operatingSystem;
		if (platform.Contains ("Windows")) {
			//playerChar.GetComponent<Syphon> ().enabled = false;
			//playerChar.GetComponent<SyphonServerTexture> ().enabled = false;
			//clientTexture.GetComponent<SyphonClientTexture> ().enabled = false;
		} else if (platform.Contains ("Mac")) {
//			playerChar.GetComponent<Syphon> ().enabled = true;
		//	playerChar.GetComponent<SyphonServerTexture> ().enabled = true;
		//	clientTexture.GetComponent<SyphonClientTexture> ().enabled = true;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
