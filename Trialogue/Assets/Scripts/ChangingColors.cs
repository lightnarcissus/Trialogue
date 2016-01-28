using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangingColors : MonoBehaviour {

	private float timer=0f;
	public bool varyAlpha=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (varyAlpha) {
			GetComponent<RawImage> ().color = new Color (Mathf.Sin (timer * 3f), Mathf.Cos (timer * 2f), Mathf.Sin (timer * 1f), Mathf.Cos (timer * 1f));
		} else {
			GetComponent<RawImage> ().color = new Color (Mathf.Sin (timer * 3f), Mathf.Cos (timer * 2f), Mathf.Sin (timer * 1f));
		}
	
	}
}
