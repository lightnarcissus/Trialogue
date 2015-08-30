using UnityEngine;
using System.Collections;

public class TreeSize : MonoBehaviour {


    private float tempScale = 1f;
    private GameObject oscManager;
    private float destroyTimer = 0f;
	// Use this for initialization
	void Start () {

        oscManager = GameObject.Find("OSCManager");
	
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
