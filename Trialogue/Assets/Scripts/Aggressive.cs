using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Aggressive : MonoBehaviour {

    private GameObject player;
	public float nice=0f;
    public static float speed = 0.5f;
	public static float colX=0f;
	public static float colY=0f;
	public static float colZ=0f;
	private Rigidbody body;
    private GameObject okay;
    private GameObject whatsup;

	// Use this for initialization
	void Start () { 
        player = GameObject.Find("Player");
		body = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		body.AddForce ((player.transform.position - transform.position).normalized * Vector3.Distance(player.transform.position,transform.position));
       // transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        transform.localScale += new Vector3(0.000001f,0.000001f,0.000001f);

		if (PlayerShoot.gameOver)
			Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		//Debug.Log ("HI: "+col.gameObject.name);
		if (col.gameObject.name == "Collider" || col.gameObject.name=="Player") {
			Aggressive.speed+=0.1f;
			if(player.GetComponent<PlayerShoot>().healthSlider.value >=0)
			{
				player.GetComponent<PlayerShoot>().healthSlider.value-=15;
				player.GetComponent<PlayerShoot>().DamageEffect();
			}
			//Debug.Log ("DESTROYING");
			Destroy (this.gameObject);
		}
	}
//
//	void OnDrawGizmosSelected() {
//		Gizmos.DrawWireMesh (gameObject.GetComponent<MeshFilter> ().mesh);
//	}

	void LateUpdate()
	{
		gameObject.GetComponent<BoxCollider> ().center = new Vector3 (colX, colY, colZ);
	}

	void OnApplicationQuit()
	{
		Debug.Log ("ice");
	}



}
