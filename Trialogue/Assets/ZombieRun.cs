using UnityEngine;
using System.Collections;

public class ZombieRun : MonoBehaviour {

	public GameObject player;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("UpdateTarget", 1f, 5f);
		agent = GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position; 
	
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.velocity.magnitude > 1f) {
			gameObject.GetComponent<Animator> ().SetBool ("Running", true);
		} else {
			gameObject.GetComponent<Animator> ().SetBool ("Running", false);
		}
	}

	void UpdateTarget()
	{

		agent.destination = player.transform.position; 
	}
}
