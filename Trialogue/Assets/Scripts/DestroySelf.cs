using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	private float timer=0f;
	public float destroyTime=3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > destroyTime) {
			if(gameObject.tag=="Paint")
			{
				transform.parent.gameObject.GetComponent<PaintManager>().RemovePaint(this.gameObject);
			}
			Destroy(gameObject);
		}
	
	}
}
