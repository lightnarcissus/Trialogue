using UnityEngine;
using System.Collections;

public class PassiveCube : MonoBehaviour {

	private GameObject player;
	public static float speed = 0.5f;
	public static float colX=0f;
	public static float colY=0f;
	public static float colZ=0f;
	private Rigidbody body;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		body = GetComponent<Rigidbody> ();
		InvokeRepeating("CheckPlayerDistance", 0.5f, 1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Collider") {
			Aggressive.speed+=0.1f;
			if(player.GetComponent<PlayerShoot>().healthSlider.value >=0)
				player.GetComponent<PlayerShoot>().healthSlider.value-=15;
			Destroy (this.gameObject);
		}
	}

	void CheckPlayerDistance()
		{
			if (Vector3.Distance (transform.position, player.transform.position) < 15f) {
				transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
			}
		}
	
	void LateUpdate()
	{
		gameObject.GetComponent<BoxCollider> ().center = new Vector3 (colX, colY, colZ);
	}
}
