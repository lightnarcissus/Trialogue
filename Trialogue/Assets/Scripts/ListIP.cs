using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ListIP : MonoBehaviour {

	public static string ipAddress="";
	public static string otherIPAddress="";
	public InputField ipField;
	public InputField otherField;
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(GameObject.Find("PlatformManager_Dev"));
		DontDestroyOnLoad (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnterApp()
	{
		Debug.Log ("ENTERING");
		ipAddress = ipField.text.ToString ();
		otherIPAddress = otherField.text.ToString ();
//		if (PlatformManager_Dev.platformVersion == 2)
//			Application.LoadLevel ("Main");
//		else
			Application.LoadLevel ("StartScreen");
	}
}
