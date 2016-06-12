using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class VideoPlay : MonoBehaviour {



	public List<MovieTexture> clips;

	// Use this for initialization
	void Start () {
		//PlayVideo (0); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayVideo(int num)
	{
		GetComponent<Renderer>().material.mainTexture = clips[num];
		clips [num].Play ();
		clips [num].loop = true;
	}
}
