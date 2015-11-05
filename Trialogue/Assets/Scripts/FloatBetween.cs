using UnityEngine;
using System.Collections;

public class FloatBetween : MonoBehaviour {

	public float speed=1f;
	private Vector3 originalPos;
	private Vector3 targetVariance;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		targetVariance = new Vector3 (Random.Range (-20f, 20f), Random.Range (0f, 10f), Random.Range (-20f, 20f));
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(Mathf.PingPong(originalPos.x+(Time.time*speed), originalPos.x+targetVariance.x), Mathf.PingPong(3f+(Time.time*speed), originalPos.y+targetVariance.y), Mathf.PingPong(250f+(Time.time*speed), originalPos.z+targetVariance.z));
	
	}
}
