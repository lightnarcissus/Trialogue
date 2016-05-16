using UnityEngine;
using System.Collections;

public class DestroyEphemeral : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DestroySpawn()
	{
		int total = transform.childCount;
		for (int i = 0; i < total; i++) {
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
