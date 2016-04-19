using UnityEngine;
using System.Collections;

public class LobbyistScript : MonoBehaviour {
    public oscControl oscControl;
    public RoleSwitcher roleSwitcher;
    public MissionSystem missionSystem;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButton("Jump"))
        {
            Debug.Log("OK");
            roleSwitcher.SwitchRole(++RoleSwitcher.currentRole);
        }
	
	}
}
