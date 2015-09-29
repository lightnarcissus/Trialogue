using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	public GameObject pistol;
	private RaycastHit hit;
	public GameObject cube;
	private Ray ray;
	private Vector3 p;
	public GameObject camera;
	public LayerMask mask=9;
	public List<AudioClip> weaponClips;
	public GameObject explosion;
	public GameObject pistolMuzzle;
	public Slider healthSlider;
	private float regenTimer=0f;
	public float regenRate=1f;
	// Use this for initialization
	void Start () {

		Debug.Log ("Width: " + Screen.width / 2 + " and Height: " + Screen.height / 2);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			//Debug.Log ("shooting");
			ray=camera.GetComponent<Camera>().ViewportPointToRay(new Vector3(GetComponent<vp_SimpleCrosshair>().offsetX,GetComponent<vp_SimpleCrosshair>().offsetY,0f));
			//ray=camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f,0f));
			pistol.GetComponent<Animator>().Play("PistolShoot");
			//Instantiate(pistolMuzzle,pistol.transform.position,Quaternion.identity);
			pistol.GetComponent<AudioSource>().PlayOneShot(weaponClips[0]);
			if(healthSlider.value>0)
				healthSlider.value-=2f;
			//Debug.DrawRay (ray.origin,ray.direction,Color.red);
			if(Physics.SphereCast(ray,0.8f, out hit,100f,mask.value))// Raycast(ray,out hit,mask.value))
			{
				if(hit.collider.gameObject.tag=="Cube")
				{
					Destroy (hit.collider.gameObject);
					Instantiate (explosion,hit.collider.gameObject.transform.position,Quaternion.identity);
					OffsetReticle();
				}
			}


		}

		regenTimer += Time.deltaTime;
		if (regenTimer * regenRate > 5f) {
			healthSlider.value++;
			regenTimer=0f;
		}
	
	}

	void OnDrawGizmosSelected() {
		p = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0f,0f, camera.GetComponent<Camera>().nearClipPlane));
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(p, 0.1F);
		Gizmos.DrawLine(ray.origin,ray.direction*5f);
	}

	public void OffsetReticle()
	{
		if (GetComponent<vp_SimpleCrosshair> ().offsetX <= 1.0f) {
			if (Random.value < 0.5f)
				GetComponent<vp_SimpleCrosshair> ().offsetX += 0.1f;
			else
				GetComponent<vp_SimpleCrosshair> ().offsetX -= 0.1f;
		}
		if (GetComponent<vp_SimpleCrosshair> ().offsetY <=1.0f) {
			if (Random.value < 0.5f)
				GetComponent<vp_SimpleCrosshair> ().offsetY += 0.1f;
			else
				GetComponent<vp_SimpleCrosshair> ().offsetY -= 0.1f;	
		}
	}
}
