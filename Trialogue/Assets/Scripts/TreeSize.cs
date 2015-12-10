using UnityEngine;
using System.Collections;

public class TreeSize : MonoBehaviour {


    private float tempScale = 1f;
    private GameObject oscManager;
    private float destroyTimer = 0f;
	public LayerMask mask=11;
	private RaycastHit hit;

	private Ray ray;
	// Use this for initialization
	void Start () {

        oscManager = GameObject.Find("OSCManager");


		//ray = ViewportPointToRay (Vector3.down);
		//ray=camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f,0f));

		//Debug.DrawRay (ray.origin,ray.direction,Color.red);
		if (Physics.Raycast (transform.position,Vector3.down, out hit, 100f, mask.value)) {// Raycast(ray,out hit,mask.value))
			if (hit.collider.gameObject.tag == "Terrain") {
				transform.position-=new Vector3(0f,hit.distance,0f);
				//Debug.Log ("hi");
			}
		}
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        destroyTimer += Time.deltaTime;
        if(destroyTimer>20f)
        {
            Destroy(gameObject);
        }
        tempScale=oscManager.GetComponent<oscControl>().treeSize;
        transform.localScale = new Vector3(tempScale, tempScale, tempScale);
		
	}
}
