using UnityEngine;
using System.Collections;

public class EnemyGroupManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnableEnemies()
	{
		int total = transform.childCount;
		for (int i = 0; i < total; i++) {
			transform.GetChild (i).gameObject.SetActive (true);
		}
	}
	public void DisableEnemies()
	{
			int total = transform.childCount;
		for (int i = 0; i < total; i++) {
			transform.GetChild (i).gameObject.SetActive (false);
		}
	}
}
