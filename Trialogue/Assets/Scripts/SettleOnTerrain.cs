using UnityEngine;
using System.Collections;

public class SettleOnTerrain : MonoBehaviour {

	public LayerMask mask=11;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {

//	`	z	if (Physics.Raycast (transform.position,Vector3.down, out hit, 100f, mask.value)) {// Raycast(ray,out hit,mask.value))
//			if (hit.collider.gameObject.tag == "Terrain") {
//				transform.position-=new Vector3(0f,hit.distance,0f);
//				//Debug.Log ("hi");
//			}
//		}
	
	}

	void FixedUpdate()
	{
		if (Physics.Raycast (transform.position,Vector3.down, out hit, 1000f, mask.value)) {// Raycast(ray,out hit,mask.value))
			if (hit.collider.gameObject.tag == "Terrain") {
				transform.position-=new Vector3(0f,hit.distance,0f);
				//Debug.Log ("hi");
			}
		}
	}
	
	// Update is called once per frame

}
