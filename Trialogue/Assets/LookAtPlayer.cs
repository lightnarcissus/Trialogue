using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
	private Transform targetIK;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		targetIK = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnAnimatorIK()
	{
		gameObject.GetComponent<Animator>().SetLookAtPosition( targetIK.position );
		gameObject.GetComponent<Animator>().SetLookAtWeight( 1f, 1f, 1f);
	}
}
