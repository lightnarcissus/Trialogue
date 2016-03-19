using UnityEngine;
using System.Collections;

public class RandomForces : MonoBehaviour {

	// Use this for initialization
	void Start () {

        InvokeRepeating("ApplyForce", 1f, 1f);  
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyForce()
    {
        //Debug.Log("applying force"); 
        GetComponent<Rigidbody>().AddForce(Random.Range(0f, 300f), Random.Range(0f, 300f),0f, ForceMode.Force);
    }
}
