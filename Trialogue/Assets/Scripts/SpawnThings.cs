using UnityEngine;
using System.Collections;

public class SpawnThings : MonoBehaviour {

	public GameObject poles;
//	public GameObject human;
	// Use this for initialization
	void Start () {
	
		for (int i=50; i<4950; i++) {
			for(int j=50;j<4950;j++)
			{
				if(Random.value<0.00001)
					Instantiate (poles,new Vector3((float)i,211.9f,(float)j),Quaternion.identity);
//				if(Random.value<0.0005)
//					Instantiate (human,new Vector3((float)i,-12.23f,(float)j),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
