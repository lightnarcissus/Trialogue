using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

    public GameObject[] trees;
    public float spawnDistance=0f;
    public float spawnRate=0.1f;
	public GameObject[] enemies;
    private int randTree = 0;
    public GameObject oscManager;
    public GameObject player;
    private float randDist = 0f;
    private float tempDist = 0f;
    private float randZDist = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value < (spawnRate * oscManager.GetComponent<oscControl>().spawnRate))
        {
			if(oscManager.GetComponent<oscControl>().enemySpawn)
			{
				Instantiate(enemies[0],player.transform.position+new Vector3(randDist*tempDist,1.58f,randDist*tempDist),Quaternion.identity);
			}
            if (oscManager.GetComponent<oscControl>().greenTrees)
                randTree = Random.Range(4, 7);
            else
                randTree = Random.Range(0, 4);
            tempDist=oscManager.GetComponent<oscControl>().spawnDistance;
            randDist = Random.Range(-8f, 8f);
            randZDist = Random.Range(-8f, 8f);
			if(trees[randTree]!=null)
            	Instantiate(trees[randTree],player.transform.position+new Vector3(randDist*tempDist,-1.58f,randDist*tempDist),Quaternion.identity);
        }
	
	}
}
