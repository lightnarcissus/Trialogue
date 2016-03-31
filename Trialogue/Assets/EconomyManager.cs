using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EconomyManager : MonoBehaviour {

    public int politicianFunds = 10000;
    public float mediaRating = 2.4f;

    public Text publicFunds;
    public Text viewerRating;

    private RoleSwitcher roleSwitcher;

	// Use this for initialization
	void Start () {
        roleSwitcher = GetComponent<RoleSwitcher>();
        publicFunds.text = "Public Funds: \n " + politicianFunds;
        viewerRating.text = "Viewer Ratings \n " + mediaRating;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
