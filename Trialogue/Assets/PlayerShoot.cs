using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject pistol;
	private RaycastHit hit;
	public GameObject cube;
	private Ray ray;
	private Vector3 p;
	public GameObject camera;
	public LayerMask mask=9;

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

			//Debug.DrawRay (ray.origin,ray.direction,Color.red);
			if(Physics.Raycast(ray,out hit,mask.value))
			{
				if(hit.collider.gameObject.tag=="Cube")
				{
					Destroy (hit.collider.gameObject);
					OffsetReticle();
				}
			}


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
		if(Random.value<0.5f)
			GetComponent<vp_SimpleCrosshair> ().offsetX+=0.1f;
		else
			GetComponent<vp_SimpleCrosshair> ().offsetX-=0.1f;

		if(Random.value<0.5f)
			GetComponent<vp_SimpleCrosshair> ().offsetY+=0.1f;	
		else
			GetComponent<vp_SimpleCrosshair> ().offsetY-=0.1f;	

	}
}
