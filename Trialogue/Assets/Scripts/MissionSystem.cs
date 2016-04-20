using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MissionSystem : MonoBehaviour {

	public int missionType=1; //1 is neutral mission, 2 is securing
	public Text playerText;
	public int numberEnemies=1;
	public int score=0;
	public oscControl oscControl;
	public float missionTimer=0f;
	public GameObject economyManager;
	private int originalNumberEnemies=0;
	private string typeEnemies="Hostiles";
	public float bestTimer = 100f;
	// Use this for initialization
	void Start () {

		
		//Debug.Log ("Mission type" + missionType);
		originalNumberEnemies = numberEnemies;
        if (missionType == 1)
        {
            numberEnemies = Random.Range(1, 15);
            playerText.text = "Neutralize " + numberEnemies + " Hostiles in the Area";
        }
        else if (missionType == 2)
        {
            numberEnemies = Random.Range(1, 5);
            string tempArea = "";
            numberEnemies = Random.Range(0, 15);
            if (oscControl.barrenLand)
            {
                tempArea = "Electric Poles";
            }
            else if (oscControl.battleArena)
            {
                tempArea = "Pillars";
            }
            else if (oscControl.battlefield)
            {
                tempArea = "Buildings";
            }
            else {
                tempArea = "Trees";
            }
            Debug.Log("yeah");
            playerText.text = "Secure " + numberEnemies + " " + tempArea;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (missionType == 2)
        {
            string tempArea = "";
            //numberEnemies = Random.Range(0, 15);
            if (oscControl.barrenLand)
            {
                tempArea = "Electric Poles";
            }
            else if (oscControl.battleArena)
            {
                tempArea = "Pillars";
            }
            else if (oscControl.battlefield)
            {
                tempArea = "Buildings";
            }
            else {
                tempArea = "Electric Poles";
            }
           // Debug.Log("yeah");
            playerText.text = "Secure " + numberEnemies + " " + tempArea;
        }
            //		if(Input.GetKeyDown(KeyCode.V))
            //			economyManager.GetComponent<RoleSwitcher>().SwitchRole(++RoleSwitcher.currentRole);
            //	
            missionTimer += Time.deltaTime;
	}

	public void GenerateNewMission()
	{
		Debug.Log ("generating new mission");
		missionTimer = 0f;
		int randMission = Random.Range (1, 3);
		missionType = randMission;
		switch (randMission) {
		case 1:
			numberEnemies = Random.Range (1, 15);
			originalNumberEnemies = numberEnemies;
			playerText.text = "Neutralize " + numberEnemies + " Hostiles in the Area";
			break;
		case 2:
               // numberEnemies = Random.Range(1, 15);
                string tempArea = "";
			numberEnemies = Random.Range (1, 5);
			originalNumberEnemies = numberEnemies;
			if (oscControl.barrenLand) {
				tempArea = "Electric Poles";
			} else if (oscControl.battleArena) {
				tempArea = "Pillars";
			} else if (oscControl.battlefield) {
				tempArea = "Buildings";
			} else {
				tempArea = "Electric Poles";
                }
			playerText.text="Secure "+numberEnemies+ " " +tempArea;
			break;
		}

	}
	public void UpdateText()
	{
		if (numberEnemies <= 0) {
			//switch roles
			score=(int) (originalNumberEnemies*missionTimer);
			//Debug.Log ("Score is" + score);
			economyManager.GetComponent<RoleSwitcher>().SwitchRole(++RoleSwitcher.currentRole);
			economyManager.GetComponent<EconomyManager> ().UpdateHeadlines ();
			if (missionTimer < bestTimer)
				bestTimer = missionTimer;
		}
		if (missionType == 1)
			playerText.text = "Neutralize " + numberEnemies + " Hostiles in the Area";
		else if (missionType == 2) {
			string tempArea = "";
			//numberEnemies = Random.Range (0, 15);
			if (oscControl.barrenLand) {
				tempArea = "Electric Poles";
			} else if (oscControl.battleArena) {
				tempArea = "Pillars";
			} else if (oscControl.battlefield) {
				tempArea = "Buildings";
			} else {
				tempArea = "Electric Poles";
			}
			playerText.text="Secure "+numberEnemies+ " " +tempArea;
		}
	}
}
