using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	// Use this for initialization
	public GameObject autoAimAssist;
	public GameObject healthUpgrade;
	public GameObject ammoUpgrade;
	public GameObject wageUpgrade;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateAim()
	{
		StartCoroutine ("AimActivate");
	}
	public void ActivateHealth()
	{
		StartCoroutine ("HealthActivate");
	}
	public void ActivateAmmo()
	{
		StartCoroutine ("AmmoActivate");
	}
	public void ActivateWage()
	{
		StartCoroutine ("WageActivate");
	}
	IEnumerator AimActivate()
	{
		Debug.Log ("autoaim");
		yield return new WaitForSeconds (1.5f);
		autoAimAssist.SetActive (true);
		yield return new WaitForSeconds (4f);
		autoAimAssist.SetActive (false);
		yield return null; 
	}
	IEnumerator HealthActivate()
	{
		Debug.Log ("health");
		yield return new WaitForSeconds (1.5f);
		healthUpgrade.SetActive (true);
		yield return new WaitForSeconds (2f);
		healthUpgrade.SetActive (false);
		yield return null; 
	}
	IEnumerator AmmoActivate()
	{
		Debug.Log ("ammo");
		yield return new WaitForSeconds (1.5f);
		ammoUpgrade.SetActive (true);
		yield return new WaitForSeconds (2f);
		ammoUpgrade.SetActive (false);
		yield return null; 
	}
	IEnumerator WageActivate()
	{
		Debug.Log ("wage");
		yield return new WaitForSeconds (1.5f);
		wageUpgrade.SetActive (true);
		yield return new WaitForSeconds (2f);
		wageUpgrade.SetActive (false);
		yield return null; 
	}
}
