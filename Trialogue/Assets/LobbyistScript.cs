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
    public Text ammoCount;
    public Text healthCount;
    public Text cogCount;

    public RawImage healthBG;
    public RawImage ammoBG;
    public RawImage cogBG;

    public Text publicFunds;

    public EconomyManager economyManager;

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

        }

        if(Input.GetAxis("Vertical") > 0.2f && waitUp)
        {
            Debug.Log("OK");
            waitUp = false;
            activeState++;
            if (activeState == 3)
                activeState = 0;
           // roleSwitcher.SwitchRole(++RoleSwitcher.currentRole);
        }
        else if(Input.GetAxis("Vertical") < -0.2f && waitUp)
        {
            waitUp = false;
            activeState--;
            if (activeState == -1)
                activeState = 2;
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
                    economyManager.politicianFunds -= (int)healthValue;
                    healthValue += 1000;
                    
                }
            }

            if(activeState==1)
            {
                if (economyManager.politicianFunds > ammoValue || oscControl.unlimitedPublicFunds)
                {
                    playerShoot.totalAmmo += 10;
                    economyManager.politicianFunds -= (int)ammoValue;
                    ammoValue += 1000;
                }
            }
            if (activeState == 2)
            {
                if (economyManager.politicianFunds > ammoValue || oscControl.unlimitedPublicFunds)
                {
                    economyManager.politicianFunds -= (int)cogValue;
                    cogValue += 2000;
                }
           }
                StartCoroutine("SwitchRole");
        }
	}

    IEnumerator SwitchRole()
    {
        yield return new WaitForSeconds(1f);
        roleSwitcher.SwitchRole(++RoleSwitcher.currentRole);
        yield return null;
    }
}
