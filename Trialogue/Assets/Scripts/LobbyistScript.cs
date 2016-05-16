using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LobbyistScript : MonoBehaviour {
    public oscControl oscControl;
    public RoleSwitcher roleSwitcher;
    public MissionSystem missionSystem;

    public float healthValue = 1000;
    public float ammoValue = 1000;
    public float cogValue = 2000;
	public float wageValue = 2500;
    public Text ammoCount;
    public Text healthCount;
    public Text cogCount;
	public Text wageCount;

    public RawImage healthBG;
    public RawImage ammoBG;
    public RawImage cogBG;
	public RawImage wageBG;

    public Text publicFunds;

	public CanvasManager canvasManager;

    public EconomyManager economyManager;
	public Color startColor;
    private RawImage currentBG;
    private bool waitUp = true;
    public PlayerShoot playerShoot;
    public int activeState = 0;
    // Use this for initialization
    void Start () {
        currentBG = healthBG;
	}

    void OnEnable()
    {

        ammoCount.text = ammoValue.ToString();
        healthCount.text = healthValue.ToString();
        cogCount.text = cogValue.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (oscControl.unlimitedPublicFunds)
        {
            publicFunds.text = "Public Funds: \n INFINITY";
        }
  
        else
            publicFunds.text = "Public Funds: \n" + economyManager.politicianFunds.ToString();

        switch(activeState)
        {
            case 0:
                currentBG.color = Color.black;
                currentBG = healthBG;
                currentBG.color = Color.green;
                break;
            case 1:
                currentBG.color = Color.black;
                currentBG = ammoBG;
                currentBG.color = Color.green;
                break;
            case 2:
                currentBG.color = Color.black;
                currentBG = cogBG;
                currentBG.color = Color.green;
                break;
		case 3:
			currentBG.color = Color.black;
			currentBG = wageBG;
			currentBG.color = Color.green;
			break;

        }
            
        if(Input.GetAxis("Vertical") < -0.2f && waitUp)
        {
            Debug.Log("OK");
            waitUp = false;
            activeState++;
            if (activeState == 4)
                activeState = 0;
           // roleSwitcher.SwitchRole(++RoleSwitcher.currentRole);
        }
        else if(Input.GetAxis("Vertical") >0.2f && waitUp)
        {
            waitUp = false;
            activeState--;
            if (activeState == -1)
                activeState = 3;
        }
	
        if(Mathf.Abs(Input.GetAxis("Vertical"))<0.2f)
        {
            waitUp = true;
        }
        if(Input.GetButtonDown("Jump"))
        {
           
            if(activeState==0)
            {
                if (economyManager.politicianFunds > healthValue || oscControl.unlimitedPublicFunds)
                {
                    playerShoot.healthSlider.maxValue += 10;
					StartCoroutine ("HealthUpgrade");
					canvasManager.ActivateHealth ();
                    economyManager.politicianFunds -= (int)healthValue;
                    healthValue += 1000;
                    
                }
            }

            if(activeState==1)
            {
                if (economyManager.politicianFunds > ammoValue || oscControl.unlimitedPublicFunds)
                {
                    playerShoot.totalAmmo += 10;
					StartCoroutine ("AmmoUpgrade");
					canvasManager.ActivateAmmo ();
                    economyManager.politicianFunds -= (int)ammoValue;
                    ammoValue += 1000;
                }
            }
            if (activeState == 2)
            {
                if (economyManager.politicianFunds > ammoValue || oscControl.unlimitedPublicFunds)
                {
                    economyManager.politicianFunds -= (int)cogValue;
					canvasManager.ActivateAim ();
					EconomyManager.autoAim = true;
                    cogValue += 2000;
                }
           }
			if (activeState == 3)
			{
				if (economyManager.politicianFunds > ammoValue || oscControl.unlimitedPublicFunds)
				{
					economyManager.maxMoney += 50;
					StartCoroutine ("WageUpgrade");
					canvasManager.ActivateWage ();
					economyManager.politicianFunds -= (int)wageValue;
					wageValue += 2000;
				}
			}
                StartCoroutine("SwitchRole");
        }
	}

	IEnumerator HealthUpgrade()
	{
		Debug.Log ("health");
		yield return null;
	}
	IEnumerator AmmoUpgrade()
	{
		Debug.Log ("ammo");
		yield return null;
	}
	IEnumerator AutoAimUpgrade()
	{
		yield return null;
	}
	IEnumerator WageUpgrade()
	{
		Debug.Log ("wage");
		yield return null;
	}
    IEnumerator SwitchRole()
    {
        yield return new WaitForSeconds(1f);
		healthBG.color = startColor;
		ammoBG.color = startColor;
		wageBG.color = startColor;
		cogBG.color = startColor;
        roleSwitcher.SwitchRole(++RoleSwitcher.currentRole);
        yield return null;
    }
}
