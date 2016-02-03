using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintManager : MonoBehaviour {

	public List<GameObject> paintList;
	public GameObject paint;
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
			if(obj!=null)
			{
			Vector2 temp=new Vector2(obj.transform.position.x-960f,obj.transform.position.y-540f);
			//Debug.Log ("paint at: "+temp);
			if(Vector2.Distance(pos,temp) < 100f)
			{
					GameObject pt=Instantiate(paint,pos,Quaternion.identity) as GameObject;
					pt.transform.parent=transform.parent;
				//Debug.Log ("hi!!!");
				RemovePaint(paintList[i]);
				Destroy(paintList[i]);
			}

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
