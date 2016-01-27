using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintManager : MonoBehaviour {

	public List<GameObject> paintList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckPaintAtPosition(Vector3 pos)
	{
		for(int i=0;i < paintList.Count;i++)
		{
			GameObject obj=paintList[i];
			if(Vector3.Distance(pos,obj.transform.position) < 10f)
			{
				Debug.Log ("hi!!!");
			}
		}
	}

	public void AddPaint(GameObject obj)
	{
		paintList.Add (obj);
	}

	public void RemovePaint(GameObject obj)
	{
		paintList.Remove (obj);
	}
}
