using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

    public GameObject[] trees;
	public GameObject[] platforms;
	public GameObject[] enemies;

	public float spawnDistance=0f;
    public float spawnRate=0.1f;

    public GameObject oscManager;
    public GameObject player;
    
	private int randTree = 0;
	private int randPlatform = 0;
	private float randDist = 0f;
    private float tempDist = 0f;
    private float randZDist = 0f;

	private int randEnemy=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
		if(oscManager.GetComponent<oscControl>().enemySpawn)
		{
			if(Random.value< (spawnRate * oscManager.GetComponent<oscControl>().enemySpawnRate))
			{
				randEnemy=Random.Range (0,2);
				Instantiate(enemies[randEnemy],player.transform.position+new Vector3(spawnDistance,0f,spawnDistance),Quaternion.identity);
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

    public void DisableEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for(int i=0;i<enemies.Length;i++)
        {
            enemies[i].gameObject.SetActive(false);
        }
    }
    public void EnableEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.SetActive(true);
        }
    }
}
