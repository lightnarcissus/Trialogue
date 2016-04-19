using UnityEngine;
using System.Collections;

public class ZombieRun : MonoBehaviour {

	public GameObject player;
	private NavMeshAgent agent;
	private bool dead = false;
	private Transform targetIK;
	public AudioClip rifleShot;
	public AvatarIKGoal ikType;
    private int soldierType = 0;
	public int behavior=1; // 1 is aggressive, 2 is defensive
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        soldierType = Random.Range(0, 2);
        if (soldierType == 1)
            gameObject.GetComponent<Animator>().SetBool("Slow", true);
         player = GameObject.Find ("Player");
		InvokeRepeating ("UpdateTarget", 1f, 5f);
		InvokeRepeating ("CheckDeath", 1f, 5f);
		agent = GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position; 
		targetIK = player.transform;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animator> ().GetBool ("Death")) {
			dead = true;
			gameObject.GetComponent<Animator> ().SetBool ("Running", false);
			gameObject.GetComponent<Animator> ().SetBool ("Shooting", false);
		}
		if (!dead) {
			if (agent.velocity.magnitude > 1f) {
				gameObject.GetComponent<Animator> ().SetBool ("Running", true);
			} else {
				gameObject.GetComponent<Animator> ().SetBool ("Running", false);
			}
			if (agent.remainingDistance < 5f) {
				gameObject.GetComponent<Animator> ().SetBool ("Shooting", true);
				if (!audioSource.isPlaying)
					audioSource.PlayOneShot (rifleShot);
				if (Random.value < 0.005f) {
					//Debug.Log ("player shot");
					player.GetComponent<PlayerShoot> ().DamageEffect ();
				}
			} else {
				gameObject.GetComponent<Animator> ().SetBool ("Shooting", false);
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
		if(dead)
		{
			if(!CubeManager.bodyRemains)
				Destroy (this.gameObject);
			else
				Destroy(gameObject.GetComponent<ZombieRun>());
		}
	}

	void OnAnimatorIK()
	{
		gameObject.GetComponent<Animator>().SetLookAtPosition( targetIK.position );
		gameObject.GetComponent<Animator>().SetLookAtWeight( 1f, 1f, 1f);
	}
}
