﻿using UnityEngine;
using System.Collections;

public class CubeManager : MonoBehaviour {

    public static float globalSizeX = 1f;
    public static float globalSizeY = 1f;
    public static float globalSizeZ = 1f;
    public static float globalSpeed = 0f;
	public static float globalSize = 1f;

    public static bool passiveActive = false;
    public static bool aggressiveActive = false;
	public static bool killCube=true;
	public static bool convertCube=false;
	public static bool spawnsMore=false;
	public static bool bodyRemains=false;
	public static bool humanEnemies=false;
//	public static bool
    private int randInt = 0;
    // Use this for initialization
    void Start () {

        InvokeRepeating("UpdateParams", 1f, 0.5f);
        randInt = Random.Range(0, 2);
        if (randInt == 0)
        {
            gameObject.GetComponent<Aggressive>().enabled = true;
            gameObject.GetComponent<PassiveCube>().enabled = false;
            passiveActive = false;
        }
        else
        {
            gameObject.GetComponent<Aggressive>().enabled = false;
            gameObject.GetComponent<PassiveCube>().enabled = true;
            aggressiveActive = false;
        }

    }
	
	// Update is called once per frame
	void Update () {

	
	}



    public void UpdateParams()
    {

        transform.localScale = new Vector3(globalSize,globalSize,globalSize);
		GetComponent<BoxCollider>().size=new Vector3(globalSizeX, globalSizeY, globalSizeZ);
        PassiveCube.speed = globalSpeed;
        Aggressive.speed = globalSpeed;

        if (passiveActive && aggressiveActive && randInt == 0)
        {
            randInt = Random.Range(0, 2);
            if (randInt == 0)
            {
                gameObject.GetComponent<Aggressive>().enabled = true;
                gameObject.GetComponent<PassiveCube>().enabled = false;
                passiveActive = false;
            }
            else
            {
                gameObject.GetComponent<Aggressive>().enabled = false;
                gameObject.GetComponent<PassiveCube>().enabled = true;
                aggressiveActive = false;
            }
        }
        else if(!passiveActive && !aggressiveActive)
        {
            gameObject.GetComponent<Aggressive>().enabled = false;
            gameObject.GetComponent<PassiveCube>().enabled = false;

        }
    }
}
