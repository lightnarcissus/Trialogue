﻿using UnityEngine;
using System.Collections;

public class RoleSwitcher : MonoBehaviour {
    public static int currentRole = 0; // 1 is soldier, 2 is politician, 3 is media, 4 is lobbyist
    public GameObject player;
    public GameObject political;
    public GameObject media;
    public GameObject lobbyist;

    public GameObject soldierObj;
    public GameObject politicalObj;
    public GameObject mediaObj;
    public GameObject lobbyistObj;
    

    private bool activateAllow = true;
    public int previousActiveRole = 0;
    // Use this for initialization
    void Start() {
        currentRole=1;
        player.SetActive(true);
        political.SetActive(false);
        media.SetActive(false);
        lobbyist.SetActive(false);

        politicalObj.SetActive(false);
        mediaObj.SetActive(false);
        lobbyistObj.SetActive(false);

    }

    // Update is called once per frame
    void Update() {

        if(activateAllow)
        { 
        if(Input.GetButton("PreviousRole"))
        {
            if (currentRole == 1)
                currentRole = 5;
            int tempInt = currentRole-1;
            SwitchRole(tempInt);
                activateAllow = false;
                StartCoroutine("AllowAgain");
                //  Debug.Log(tempInt);

            }
        else if(Input.GetButton("NextRole"))
        {
            if (currentRole == 4)
                currentRole = 0;
            int tempInt = currentRole + 1;
            SwitchRole(tempInt);
                activateAllow = false;
                StartCoroutine("AllowAgain");
                //Debug.Log(tempInt);
            }
        }

      //  Debug.Log(currentRole);

    }


    IEnumerator AllowAgain()
    {
        yield return new WaitForSeconds(1f);
        activateAllow = true;
        yield return null;
    }

    public void SwitchRole(int activateRole)
    {
        switch (activateRole)
        {
            case 1:
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<PlayerShoot>().enabled = true;
                DisableRole(currentRole);
                soldierObj.SetActive(true);
                currentRole = activateRole;
                break;
            case 2:
                political.SetActive(true);
                DisableRole(currentRole);
                politicalObj.SetActive(true);
                currentRole = activateRole;
                break;
            case 3:
                media.SetActive(true);
                DisableRole(currentRole);
                mediaObj.SetActive(true);
                currentRole = activateRole;
                break;
            case 4:
                lobbyist.SetActive(true);
                DisableRole(currentRole);
                lobbyistObj.SetActive(true);
                currentRole = activateRole;
                break;

        }
    }

    void DisableRole(int disabledRole)
    {
        switch(disabledRole)
        {
            case 1:
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<PlayerShoot>().enabled = false;
                soldierObj.SetActive(false);
                break;
            case 2:
                political.SetActive(false);
                politicalObj.SetActive(false);
                break;
            case 3:
                media.SetActive(false);
                mediaObj.SetActive(false);
                break;
            case 4:
                lobbyist.SetActive(false);
                lobbyistObj.SetActive(false);
                break;

        }
    }
        
  }
