using UnityEngine;
using System.Collections;

public class TilingAnimator : MonoBehaviour {

	private Material localMat;
	// Use this for initialization
	void Start () {
		localMat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {

		localMat.mainTextureScale = new Vector2 (Mathf.Sin (0.01f * Time.time), Mathf.Sin (0.02f * Time.time));
	
	}
}
