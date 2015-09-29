using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Aggressive : MonoBehaviour {

    private GameObject player;
    public static float speed = 0.5f;
	public static float colX=0f;
	public static float colY=0f;
	public static float colZ=0f;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        transform.localScale += new Vector3(0.000001f,0.000001f,0.000001f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Collider") {
			Aggressive.speed+=0.1f;
			if(player.GetComponent<PlayerShoot>().healthSlider.value > 15)
				player.GetComponent<PlayerShoot>().healthSlider.value-=15;
			Destroy (this.gameObject);
		}
	}

	void LateUpdate()
	{
		gameObject.GetComponent<BoxCollider> ().center = new Vector3 (colX, colY, colZ);
	}



}
