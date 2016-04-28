using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoveSliders : MonoBehaviour {

    public Slider targetSlider;
    private Vector3 startPos;
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateSliders", 2f, 2f);
        startPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = new Vector3(startPos.x, transform.localPosition.y, startPos.z);
	}

    void UpdateSliders()
    {

    }
}
