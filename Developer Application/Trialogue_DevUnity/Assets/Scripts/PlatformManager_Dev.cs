using UnityEngine;
using System.Collections;

public class PlatformManager_Dev : MonoBehaviour {

	public string platform;
	public static int platformVersion=0;
	// Use this for initialization
	void Start () {
		platform = SystemInfo.operatingSystem;
		if(platform.Contains("Windows"))
			{
			platformVersion = 0;
			}
		else if(platform.Contains("Mac"))
		{
			platformVersion = 1;
		}
		if(platform.Contains("iOS"))
		{
			platformVersion = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
