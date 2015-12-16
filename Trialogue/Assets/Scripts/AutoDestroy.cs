using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {



	// Use this for initialization
	void Start () {

		StartCoroutine ("DestroySelf");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DestroySelf()
	{
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
		yield return null;
	}
}
