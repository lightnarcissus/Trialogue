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
	private GameObject targetCube;
	public bool friendly=false;
	private GameObject treeGen;
	private GameObject target;
	// Use this for initialization
	void Start () { 
        player = GameObject.Find("Player");
		treeGen = GameObject.Find ("TreeGenerator");
		body = GetComponent<Rigidbody> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerShoot.gameOver)
			Destroy (gameObject);
	}

	void FixedUpdate()
	{
		if (!friendly)
			body.AddForce ((player.transform.position - transform.position).normalized * 0.01f * Vector3.Distance (player.transform.position, transform.position), ForceMode.VelocityChange);
		else {
			GetComponent<Renderer>().material.color=Color.green;
			if(target!=null)
				body.AddForce((target.transform.position - transform.position).normalized * 0.01f * Vector3.Distance (target.transform.position, transform.position), ForceMode.VelocityChange);
			else
			{
				if(treeGen!=null)
				{
					treeGen = GameObject.Find ("TreeGenerator");
				}
				else
					target=treeGen.GetComponent<TreeGenerator>().TargetEnemies(this.gameObject);
			}

		}
		//	body.AddForce (Vector3.MoveTowards (transform.position, player.transform.position, 1f) * Vector3.Distance (player.transform.position, transform.position), ForceMode.Acceleration);
		// transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
		// transform.localScale += new Vector3(0.000001f,0.000001f,0.000001f);

	}

	void TargetEnemy()
	{

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
			//Debug.Log ("DESTROYING");
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
		//Debug.Log ("ice");
	}



}
