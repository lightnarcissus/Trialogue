using UnityEngine;
using System.Collections;

public class SettleOnTerrain : MonoBehaviour {

	public LayerMask mask=11;
	private RaycastHit hit;
	public static int terrainStatus = 0; //0 for barren land, 1 for arena, 2 for war
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CheckStatus", 1f, 1f);
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

	void CheckStatus()
	{
		if (terrainStatus == 0) {
			transform.GetChild (0).gameObject.SetActive (true);
			transform.GetChild (1).gameObject.SetActive (false);
			transform.GetChild (2).gameObject.SetActive (false);
        }
		else if (terrainStatus == 1) {
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.SetActive (false);
			transform.GetChild (2).gameObject.SetActive (false);
		} else if (terrainStatus == 2) {
			transform.GetChild(1).gameObject.SetActive (true);
			transform.GetChild(0).gameObject.SetActive (false);
			transform.GetChild(2).gameObject.SetActive (false);
		}		else if (terrainStatus == 3)
		{
		//	Debug.Log ("battlefield activated");
			transform.FindChild("War").gameObject.SetActive (true);
			transform.GetChild(0).gameObject.SetActive (false);
			transform.GetChild(1).gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame

}
