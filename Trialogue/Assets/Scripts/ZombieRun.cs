using UnityEngine;
using System.Collections;

public class ZombieRun : MonoBehaviour {

	public GameObject player;
	private NavMeshAgent agent;
	private bool dead = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		InvokeRepeating ("UpdateTarget", 1f, 5f);
		InvokeRepeating ("CheckDeath", 1f, 5f);
		agent = GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position; 
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			if (agent.velocity.magnitude > 1f) {
				gameObject.GetComponent<Animator> ().SetBool ("Running", true);
			} else {
				gameObject.GetComponent<Animator> ().SetBool ("Running", false);
			}
		}
	}

	void UpdateTarget()
	{
		if (!dead)
		agent.destination = player.transform.position; 
	}

	void CheckDeath()
	{
		if (GetComponent<Animator> ().GetBool ("Death")) {
			dead=true;
			if(!CubeManager.bodyRemains)
				Destroy (this.gameObject);
			else
				Destroy(gameObject.GetComponent<ZombieRun>());
		}
	}
}
