using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class RandomizePR : MonoBehaviour {

	public List<string> available;
	public List<string> used;
	public int options=9;
	public InputField prLine;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < options; i++) {
			int temp = Random.Range (0, options-i);
			used[i]=available [temp];
			available.RemoveAt (temp);
			transform.GetChild (i).GetChild (0).GetComponent<Text> ().text = used [i];
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPRWord(GameObject obj)
	{
		prLine.text += " " + obj.transform.GetChild(0).gameObject.GetComponent<Text> ().text;
	}
	public void ClearLine()
	{
		prLine.text = "";
	}
}
