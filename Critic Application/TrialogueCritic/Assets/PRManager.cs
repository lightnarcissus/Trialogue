using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PRManager : MonoBehaviour {

    public List<string> prText;
    private int stringCount = 0;
	// Use this for initialization
	void Start () {

       // InvokeRepeating("UpdatePRText", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdatePRText()
    {
        int total = transform.childCount;
        for(int i=0;i< total;i++)
        {
            string tempString = transform.GetChild(i).gameObject.GetComponent<TextMesh>().text;
            for(int j=0;j<prText.Count;j++)
            {
                if(prText.Contains(tempString))
                {
                    Debug.Log("FOUND IT");
                    prText.Add(transform.GetChild(i).gameObject.GetComponent<TextMesh>().text);
                }
            }
            
        }
    }



	public void Clear()
	{
		int total = transform.childCount;
		for (int i = 0; i < total; i++) {
			Destroy (transform.GetChild (i).gameObject);
		}
	}
}
