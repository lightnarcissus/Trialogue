﻿using UnityEngine;
using System.Collections;

public class PassiveCube : MonoBehaviour {

	private GameObject player;
	public static float speed = 0.5f;
	public static float colX=0f;
	public static float colY=0f;
	public static float colZ=0f;
	private Rigidbody body;
	public bool friendly=false;
	private GameObject treeGen;
	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		treeGen = GameObject.Find ("Spawner");
		body = GetComponent<Rigidbody> ();
		InvokeRepeating("CheckPlayerDistance", 0.5f, 1f);
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = new Vector3(CubeManager.globalSize, CubeManager.globalSize, CubeManager.globalSize);
	
	}

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("HI: "+col.gameObject.name);
		if (col.gameObject.name == "Player") {
			Aggressive.speed += 0.1f;
			if (col.gameObject.GetComponent<PlayerShoot> ().healthSlider.value >= 0) {
				col.gameObject.GetComponent<PlayerShoot> ().healthSlider.value -= 15;
				col.gameObject.GetComponent<PlayerShoot> ().DamageEffect ();
				Vector3 temp=new Vector3(transform.position.x,transform.position.y); // 1.7 for x 1.5 for y
				col.gameObject.GetComponent<PlayerShoot> ().FindCubePos(transform.position);
			}
				Destroy (this.gameObject);
		} else if (col.gameObject.name == "Collider") {
			Aggressive.speed += 0.1f;
			if (col.transform.parent.gameObject.GetComponent<PlayerShoot> ().healthSlider.value >= 0) {
				col.transform.parent.GetComponent<PlayerShoot> ().healthSlider.value -= 15;
				col.transform.parent.GetComponent<PlayerShoot> ().DamageEffect ();
			}
			//Debug.Log ("DESTROYING");
			TreeGenerator.cubes.Remove (gameObject);
			Destroy (this.gameObject);
			
		}
	}

	void CheckPlayerDistance()
		{
			if (Vector3.Distance (transform.position, player.transform.position) < 15f) {
			for(float i=0f;i<=1f || Vector3.Distance (transform.position,player.transform.position) >15f;i+=0.01f)
				body.AddForce ((player.transform.position - transform.position).normalized * Vector3.Distance(player.transform.position,transform.position));
			}
		}
	
	void LateUpdate()
	{
		gameObject.GetComponent<BoxCollider> ().center = new Vector3 (colX, colY, colZ);
	}
}
