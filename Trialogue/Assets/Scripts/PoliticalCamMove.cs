using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PoliticalCamMove : MonoBehaviour {
	public float XSensitivity = 2f;
	private bool controllerAttached=false;
	public float YSensitivity = 2f;
	public GameObject playerShoot;
	private float shootTrigger = 0f;
	private bool shootUp = false;
	private int platformID=0;
	public RoleSwitcher roleSwitcher;
	public GameObject politicalSphere;
	public GameObject ephemeral;

	public EconomyManager economyManager;
	// Use this for initialization
	void Start () {
		string[] contList = Input.GetJoystickNames ();
		//Debug.Log (contList.Length);
		for (int i = 0; i < contList.Length; i++) {
			Debug.Log (contList [i]);
			if (contList [i].Contains ("360")) {
			//	Debug.Log ("INSIDE");
				controllerAttached = true;
			}
		}

	}

	void OnEnable()
	{
		economyManager.UpdatePublicFunds ();
	}

	void Awake()
	{
		platformID = playerShoot.GetComponent<PlayerShoot> ().platformID;
	}
	
	// Update is called once per frame
	void Update () {
		float xRot=0f;
		float yRot=0f;
		float zRot = 0f;
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
            yRot = CrossPlatformInputManager.GetAxis("Mouse Y") * XSensitivity;
            zRot = CrossPlatformInputManager.GetAxis("Vertical") * XSensitivity;
            xRot = CrossPlatformInputManager.GetAxis("Horizontal") * YSensitivity;
        } else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer && controllerAttached) {
			yRot = CrossPlatformInputManager.GetAxis ("Mouse Y") * XSensitivity;
			zRot=CrossPlatformInputManager.GetAxis ("Vertical") * XSensitivity;
			xRot = CrossPlatformInputManager.GetAxis ("Horizontal") * YSensitivity;
		}
		if(transform.localPosition.y > -5f)
		transform.localPosition+= new Vector3(xRot,-5f,zRot);
		else
		transform.localPosition+= new Vector3(xRot,yRot,zRot);
		
		if(platformID==1)
			shootTrigger = Input.GetAxis("Shoot");
		else
			shootTrigger =Input.GetAxis("ShootMac");
		//Debug.Log(Mathf.Abs(shootTrigger));
		if(Mathf.Abs(shootTrigger)<0.1f)
		{
			shootUp = true;
			// StartCoroutine("DontShoot");
		}
		if (Input.GetMouseButtonDown (0) ||(shootUp && (Mathf.Abs(shootTrigger)>0.5f))) {
			GameObject sphere=Instantiate(politicalSphere,new Vector3(transform.position.x,118.3f,transform.position.z),Quaternion.identity) as GameObject;
			sphere.transform.parent = ephemeral.transform;
			shootUp = false;
			economyManager.DecreasePublicFunds ();
			economyManager.UpdatePublicFunds ();
			StartCoroutine ("SwitchRole");
		}
	}

	IEnumerator SwitchRole()
	{
		yield return new WaitForSeconds (1f);
		roleSwitcher.SwitchRole (++RoleSwitcher.currentRole);
		yield return null;
	}
	public void SwitchPlayer()
	{
		Debug.Log ("hi");
		playerShoot.SetActive (true);
		gameObject.SetActive (false);
	}
}
