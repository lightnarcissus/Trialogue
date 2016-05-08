using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MetaManager : MonoBehaviour {

	public int metaLimit=0;

	// Use this for initialization
	void Start () {

		if(gameObject.GetComponent<bl_ToggleSwitcher>() != null)
			GetComponent<bl_ToggleSwitcher> ().isOn = false;
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
