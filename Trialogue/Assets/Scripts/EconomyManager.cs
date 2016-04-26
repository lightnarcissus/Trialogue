using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EconomyManager : MonoBehaviour {

    public int politicianFunds = 10000;
    public float mediaRating = 2.4f;
	public Text playerText;
    public Text headlineText;
	public Text rankText;
	public Text scoreText;
	public Text killsText;
	public Text deathText;
	public Text ratioText;

	public oscControl oscControl;

	public MissionSystem missionManager;
	public Text publicFunds;
    public Text viewerRating;
	public PlayerShoot playerShoot;
    private RoleSwitcher roleSwitcher;

	public int maxMoney = 100;



	// Use this for initialization
	void Start () {
        roleSwitcher = GetComponent<RoleSwitcher>();
		publicFunds.text = "Public Funds: \n" + politicianFunds.ToString ();
		if(playerText.text.Contains("Neutralize"))
			headlineText.text = "Our Troops Defeat Enemy Forces";
		else if(playerText.text.Contains("Secure"))
			headlineText.text = "Local Town Secured By Our Troops";
        viewerRating.text = "Viewer Ratings \n " + mediaRating;
	}
	
	// Update is called once per frame
	void Update () {

     //   Debug.Log(politicianFunds);
	
	}

	public void DecreasePublicFunds()
	{
		politicianFunds -= 1000;
	}

	public void UpdatePublicFunds()
	{
        if (oscControl.unlimitedPublicFunds)
        {
            publicFunds.text = "Public Funds: \n INFINITY";
           // politicianFunds = -1;
        }
        else
        {
            publicFunds.text = "Public Funds: \n" + politicianFunds.ToString();
           // politicianFunds = 10000;
        }
		
	}

	public void UpdateHeadlines()
	{
		rankText.text = "1";
		scoreText.text = missionManager.score.ToString ();
		killsText.text = playerShoot.killCount.ToString ();
		deathText.text = playerShoot.deathCount.ToString ();
		float deathRatio = 0f;
		if (playerShoot.deathCount != 0) {
			deathRatio = (float)(playerShoot.killCount / playerShoot.deathCount);
			ratioText.text = deathRatio.ToString ("F2");
		} else
			ratioText.text = "INFINITY";
		if(oscControl.mediaCensorship)
        {
            headlineText.text = "Are Harmful Games Violent?";
        }
		else if (playerText.text.Contains ("Neutralize"))
			headlineText.text = "Our Troops Defeat Enemy Forces";
		else if(playerText.text.Contains("Secure"))
			headlineText.text = "Local Town Secured By Our Troops";
		
		viewerRating.text = "Viewer Ratings \n " + mediaRating;
	}

}
