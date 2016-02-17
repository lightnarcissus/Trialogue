using UnityEngine;
using System.Collections;

public class DevManager : MonoBehaviour {

	public bool[] menuSelected;
	public GameObject[] selectLights;
	public GameObject[] optionSets;
	public int currentlySelected=0;
	// Use this for initialization
	void Start () {
	
		for (int i=0; i<menuSelected.Length; i++) {
			selectLights[currentlySelected].SetActive (true);
			selectLights[i].SetActive (false);
			optionSets[i].SetActive (false);
		}
		
		optionSets[currentlySelected].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateMenuOption(int i)
	{
		menuSelected [currentlySelected] = false;
		menuSelected [i] = true;
		currentlySelected = i;
		UpdateMenu ();
	}

	public void UpdateMenu()
	{
		for (int i=0; i<menuSelected.Length; i++) {
			selectLights[currentlySelected].SetActive (true);
			selectLights[i].SetActive (false);
			optionSets[i].SetActive (false);
		}
		
		optionSets[currentlySelected].SetActive (true);
	}
}
