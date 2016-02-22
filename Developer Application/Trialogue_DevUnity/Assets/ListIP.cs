using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ListIP : MonoBehaviour {

	public static string ipAddress="";
	public InputField ipField;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnterApp()
	{
		ipAddress = ipField.text.ToString ();
		Application.LoadLevel ("Main");
	}
}
