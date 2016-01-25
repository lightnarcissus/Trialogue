using UnityEngine;
using System.Collections;

public class SpawnThings : MonoBehaviour {

	public GameObject poles;
	public GameObject poleManager;
	private GameObject tempObj;
//	public GameObject human;
	// Use this for initialization
	void Start () {
	
		for (int i=50; i<4950; i++) {
			for(int j=50;j<4950;j++)
			{
				if(Random.value<0.00001)
				{
					tempObj=Instantiate (poles,new Vector3((float)i,211.9f,(float)j),Quaternion.identity)as GameObject;
					tempObj.transform.parent=poleManager.transform;
				}
//				if(Random.value<0.0005)
//					Instantiate (human,new Vector3((float)i,-12.23f,(float)j),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
