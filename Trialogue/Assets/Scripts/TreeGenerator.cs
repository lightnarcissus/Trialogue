using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeGenerator : MonoBehaviour {

    public GameObject[] trees;
	public GameObject[] platforms;
	public GameObject[] enemies;

	public float spawnDistance=0f;
    public float spawnRate=0.1f;

    public GameObject oscManager;
    public GameObject player;
	private GameObject tempCube;
	public static List<GameObject> cubes=new List<GameObject>();
    
	private int randTree = 0;
	private int randPlatform = 0;
	private float randDist = 0f;
    private float tempDist = 0f;
    private float randZDist = 0f;

	private bool disableSpawn=false;
	private int randEnemy=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (cubes.Count);
        if (oscManager.GetComponent<oscControl>().treeSpawn)
        {
            if (Random.value < (spawnRate * oscManager.GetComponent<oscControl>().spawnRate))
            {
                if (oscManager.GetComponent<oscControl>().greenTrees)
                    randTree = Random.Range(4, 7);
                else
                    randTree = Random.Range(0, 4);
                tempDist = oscManager.GetComponent<oscControl>().spawnDistance;
                randDist = Random.Range(-8f, 8f);
                randZDist = Random.Range(-8f, 8f);
                if (trees[randTree] != null)
                    Instantiate(trees[randTree], player.transform.position + new Vector3(randDist * tempDist, -1.58f, randDist * tempDist), Quaternion.identity);
            }
        }
		if(oscManager.GetComponent<oscControl>().enemySpawn && !disableSpawn)
		{
			if(Random.value< (spawnRate * oscManager.GetComponent<oscControl>().enemySpawnRate))
			{
                if (CubeManager.humanEnemies)
                    randEnemy = Random.Range(2, 4);
				else
					randEnemy=Random.Range (0,2);

				tempCube=Instantiate(enemies[randEnemy],player.transform.position+new Vector3(spawnDistance,0f,spawnDistance),Quaternion.identity) as GameObject;
				cubes.Add (tempCube);
			}
		}

        /*
		if(oscManager.GetComponent<oscControl>().platformSpawn)
		{
			if(Random.value< (spawnRate * oscManager.GetComponent<oscControl>().platformSpawnRate))
			{
				randPlatform=Random.Range (0,4);
				Instantiate(platforms[randPlatform],player.transform.position+new Vector3(randDist*tempDist,player.transform.position.y,randDist*tempDist),Quaternion.identity);
			}
		}
        */
	
	}

	public GameObject TargetEnemies(GameObject targeter)
	{
		for (int i=0; i<cubes.Count; i++) {
			if(cubes[i].GetComponent<Aggressive>().enabled)
			{
				if(cubes[i].GetComponent<Aggressive>().friendly)
				{
					return cubes[i];
				//	break;
				}
				if(cubes[i].GetComponent<PassiveCube>().friendly)
				{
					return cubes[i];
					//	break;
				}
			}
		}
		return null;
	}

    public void DisableEnemies()
    {
		disableSpawn = true;
        Debug.Log("disabling"); 
       // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Cube");
        for(int i=0;i<cubes.Count;i++)
        {
			if(cubes[i]!=null)
				cubes[i].gameObject.SetActive(false);
			else
				cubes.RemoveAt(i);
        }
    }
    public void EnableEnemies()
    {
		disableSpawn = false;
      //  GameObject[] enemies = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i <cubes.Count; i++)
        {
			if(cubes[i]!=null)
				cubes[i].gameObject.SetActive(true);
			else
				cubes.RemoveAt(i);
        }
    }
}
