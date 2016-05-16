using UnityEngine;
using System.Collections;

public class PRManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clear()
	{
		int total = transform.childCount;
		for (int i = 0; i < total; i++) {
			Destroy (transform.GetChild (i));
		}
	}
}
