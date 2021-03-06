﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized; 
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerShoot : MonoBehaviour {

	public GameObject pistol;
	public GameObject paintBrush;
	private RaycastHit hit;
	public GameObject cube;
	public GameObject zombie;
	private Ray ray;
	private Vector3 p;
	public GameObject playerSound;
	public AudioClip bulletHit;
    public GameObject poppyFlower;
	public GameObject deathField;
	public GameObject terrainObj;

    public Text ammoText;
    public Text healthText;

	public Texture2D tempTexture1;


	//score
	public int killCount=0;
	public int deathCount=0;

	//money
	public int soldierMoney=100;
	public Text subtractMoney;
	public Text moneyValue;

    public int ammoCount = 30;
    public int totalAmmo = 30;
	//cameras
	public GameObject whiteCam;
	public GameObject cameraPlay;

	public LayerMask mask=9;
	public List<AudioClip> weaponClips;
	public GameObject dyingSound;
	public GameObject explosionSound;
	public GameObject explosion;
    public GameObject humanExplosion;
	public GameObject pistolMuzzle;
	public Slider healthSlider;
	public GameObject oscManager;
	private float regenTimer=0f;
	public float regenRate=1f;
	private Vector3 muzzleSpawnPos = new Vector3 (0f, 0.16f, 0.7286987f);
    public Text gameOverText;
    public static bool gameOver = false;
	private GameObject tempMuzzle;

	public GameObject canvas;
    private float shootTrigger = 0f;

	public RawImage flashTexture;
    private bool shootUp = false;
	private float flashTimer=0f;

	public bool paintAllow=true; //change to false afterwards
	public GameObject paintManager;
	public GameObject paintSplash;
	public GameObject platformManager;
	public int platformID=0;
	public GameObject economyManager;
	public GameObject missionManager;
	private Ray autoRay;
	// Use this for initialization
	void Start () {
        ammoCount = totalAmmo;
		if (platformManager.GetComponent<PlatformManager> ().platform.Contains ("Windows"))
			platformID = 1;
		else if (platformManager.GetComponent<PlatformManager> ().platform.Contains ("Mac"))
			platformID = 2;
		cameraPlay.GetComponent<Camera> ().enabled = false;
        cameraPlay.GetComponent<Camera> ().enabled = true;
		flashTexture.enabled = false;
		UnityEngine.Cursor.visible = false;
		Debug.Log ("Width: " + Screen.width / 2 + " and Height: " + Screen.height / 2);
		subtractMoney.enabled = false;
		terrainObj.GetComponent<TerrainToolkit> ().tempTexture = tempTexture1;
		//Debug.Log ("pixelwidth: "+cameraPlay.GetComponent<Camera>().pixelWidth.ToString ());
		//Debug.Log ("pixelHeight: "+cameraPlay.GetComponent<Camera>().pixelHeight.ToString ());
		InvokeRepeating("AutoAimCheck",0.3f,0.15f);

	}
	
    void Awake()
    {
        ammoCount = totalAmmo;
		//soldierMoney = 100;
		moneyValue.text = soldierMoney.ToString ();
    }
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
          //  Debug.Log(CubeManager.aggressiveActive);
            healthText.text = healthSlider.value.ToString();
            ammoText.text = ammoCount.ToString() + "/" + totalAmmo.ToString() ;
//			Debug.Log (Input.GetAxis ("ShootMac"));
			if (transform.position.y < 90f)
					GameOver ();
			if(platformID==1)
            { 
            	shootTrigger = Input.GetAxis("Shoot");
                if (Mathf.Abs(shootTrigger) < 0.2f)
                {
                    shootUp = true;
                    // StartCoroutine("DontShoot");
                }
            }
            else
            { 
				shootTrigger =Input.GetAxis("ShootMac");
                if (shootTrigger < -0.5f)
                {
                    shootUp = true;
                    // StartCoroutine("DontShoot");
                }
            }
            //Debug.Log(Mathf.Abs(shootTrigger));
            
			//Debug.Log (shootUp + " " + shootTrigger);
            
			if(paintAllow)
			{
				paintBrush.SetActive (true);
				pistol.SetActive (false);
		/*	GameObject obj=Instantiate (paintSplash,transform.position,Quaternion.identity)as GameObject;
			obj.transform.parent=paintManager.transform;
				obj.transform.eulerAngles=Vector3.zero;
			//	Debug.Log ("After parenting "+obj.transform.position);
				obj.transform.localScale=Vector3.one;
			//cameraPlay.GetComponent<PP_Charcoal>().enabled=true;
			//	Vector3 splashPos=Input.mousePosition;
			Vector3 splashPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
				splashPos=new Vector3(splashPos.x-2000f,splashPos.y,0f);
				obj.transform.position=splashPos;
				obj.transform.position=splashPos;
				//Debug.Log ("after mousepos "+obj.transform.position + " and " + obj.GetComponent<RectTransform>().position);
			paintManager.GetComponent<PaintManager>().AddPaint(obj);
            */
			}
			else if (Input.GetMouseButtonDown (0) ||(shootUp && (shootTrigger>0.5f))) {

               
			//	cameraPlay.GetComponent<PP_Charcoal>().enabled=false;
			   // Debug.Log ("shooting");
				
                //ray=camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f,0f));
                if (ammoCount > 0)
                {
                    ammoCount--;
                    ray = cameraPlay.GetComponent<Camera>().ViewportPointToRay(new Vector3(GetComponent<vp_SimpleCrosshair>().offsetX, GetComponent<vp_SimpleCrosshair>().offsetY, 0f));
                    pistol.GetComponent<Animator> ().Play ("PistolShoot");
                shootUp = false;
				//Instantiate(pistolMuzzle,pistol.transform.position,Quaternion.identity);
				pistol.GetComponent<AudioSource> ().PlayOneShot (weaponClips [0]);
				tempMuzzle=Instantiate (pistolMuzzle,pistol.transform.localPosition,Quaternion.identity)as GameObject;
				tempMuzzle.transform.parent=pistol.transform;
				tempMuzzle.transform.localPosition=muzzleSpawnPos;
				if (gameObject.GetComponent<vp_SimpleCrosshair> ().overruleOffset) {
					gameObject.GetComponent<vp_SimpleCrosshair> ().IncreaseCopies ();
				}
				if (healthSlider.value >= 0 && oscManager.GetComponent<oscControl> ().healthAmmo)
					healthSlider.value -= 2f;
                }
                //Debug.DrawRay (ray.origin,ray.direction,Color.red);
                if (Physics.SphereCast (ray, 0.8f, out hit, 100f, mask.value)) {// Raycast(ray,out hit,mask.value))

//					GameObject obj=Instantiate (paintSplash,transform.position,Quaternion.identity)as GameObject;
//					obj.transform.parent=canvas.transform;
//					Vector3 splashPos=cameraPlay.GetComponent<Camera>().ViewportToScreenPoint(new Vector3 (GetComponent<vp_SimpleCrosshair> ().offsetX, GetComponent<vp_SimpleCrosshair> ().offsetY, 0f));
//					obj.transform.position=splashPos;
					if (hit.collider.gameObject.tag == "Health") {
						Destroy (hit.collider.gameObject);
						if (healthSlider.value < healthSlider.maxValue - 20f && soldierMoney >= 20) {
							StartCoroutine ("SubtractMoney");
							healthSlider.value += 20f;
						} else if(soldierMoney >= 20 && healthSlider.value!=healthSlider.maxValue)
						{
							StartCoroutine ("SubtractMoney");
							healthSlider.value = healthSlider.maxValue;
						}
					}
					if (hit.collider.gameObject.tag == "Cube") {
						killCount++;
						if (missionManager.GetComponent<MissionSystem> ().missionType == 1) {
							missionManager.GetComponent<MissionSystem> ().numberEnemies--;
							missionManager.GetComponent<MissionSystem> ().UpdateText();
						}
						TreeGenerator.cubes.Remove (hit.collider.gameObject);
						if(CubeManager.spawnsMore)
						{
							Instantiate (cube,transform.position,Quaternion.identity);
						}
						if(CubeManager.convertCube)
						{
							//Debug.Log ("cube converted");
							hit.collider.gameObject.GetComponent<Aggressive>().friendly=true;
							hit.collider.gameObject.GetComponent<PassiveCube>().friendly=true;
						}
						if(CubeManager.killCube)
						{
							//Debug.Log ("cube destroyed");
							if(!CubeManager.bodyRemains)
							{
								hit.collider.gameObject.GetComponent<Renderer>().material.color=Color.red;
								Destroy (hit.collider.gameObject);
							}
						Instantiate (explosionSound,transform.position,Quaternion.identity);
						Instantiate (explosion, hit.collider.gameObject.transform.position, Quaternion.identity);
						}

						OffsetReticle ();
					}
					if(hit.collider.gameObject.tag=="Human")
					{
						killCount++;
						hit.collider.gameObject.GetComponent<Animator>().SetBool("Death",true);
                        Instantiate(explosionSound, transform.position, Quaternion.identity);
                        Instantiate(humanExplosion, hit.collider.gameObject.transform.position, Quaternion.identity);
                        Instantiate(poppyFlower, hit.collider.gameObject.transform.position, Quaternion.identity);
                        hit.collider.gameObject.GetComponent<NavMeshAgent>().enabled=false;
						if (missionManager.GetComponent<MissionSystem> ().missionType == 1) {
							missionManager.GetComponent<MissionSystem> ().numberEnemies--;
							missionManager.GetComponent<MissionSystem> ().UpdateText();
						}

						if(CubeManager.spawnsMore)
						{
							Instantiate (zombie,transform.position,Quaternion.identity);
						}
						if(CubeManager.convertCube)
						{
							//Debug.Log ("cube converted");
							//hit.collider.gameObject.GetComponent<Aggressive>().friendly=true;
							//hit.collider.gameObject.GetComponent<PassiveCube>().friendly=true;
						}
						if(CubeManager.killCube)
						{
							//Debug.Log ("cube destroyed");
							if(!CubeManager.bodyRemains)
							{
								//hit.collider.gameObject.GetComponent<Renderer>().material.color=Color.red;
								//Destroy (hit.collider.gameObject);
							}
							Instantiate (dyingSound,hit.collider.gameObject.transform.position,Quaternion.identity);
							//Instantiate (explosionSound,transform.position,Quaternion.identity);
							//Instantiate (explosion, hit.collider.gameObject.transform.position, Quaternion.identity);
						}

					}

				}


			}
			else
			{
				//cameraPlay.GetComponent<PP_Charcoal>().enabled=false;
				paintBrush.SetActive (false);
				pistol.SetActive (true);
			}
        

			if (healthSlider.value < 2) {
				healthSlider.value = 0;
				GameOver ();
			}
			if(oscManager.GetComponent<oscControl> ().regenHealth)
			{
			regenTimer += Time.deltaTime;
			if (regenTimer * 2f > 5f) {
				if(healthSlider.value <=98)
					healthSlider.value+=2;
				regenTimer = 0f;
			}
			}
		}
		else
		{
			//flashTimer+=Time.deltaTime;
			if(Input.GetKeyDown(KeyCode.Tab))
			{
				gameOver = false;
				RestartGame();
			}
		}
	
	}

	public void Reset()
	{
		healthSlider.value = 100;
		healthSlider.maxValue = 100;
		ammoCount = 30;
		totalAmmo = 30;
		EconomyManager.autoAim = false;

	}

	void AutoAimCheck()
	{
		if (EconomyManager.autoAim) {
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) {
					autoRay = cameraPlay.GetComponent<Camera> ().ViewportPointToRay (new Vector3 (i / 10f, j / 10f, 0f));	
					if (Physics.SphereCast (autoRay, 0.8f, out hit, 100f, mask.value)) {
						if (hit.collider.gameObject.tag == "Cube") {
							//Debug.Log ("Found an enemy");
							GetComponent<vp_SimpleCrosshair> ().offsetX = i / 10f;
							GetComponent<vp_SimpleCrosshair> ().offsetY = j / 10f;

						}
					}
				}
			}
		}
	}

	IEnumerator SubtractMoney()
	{
		subtractMoney.enabled = true;
		soldierMoney -= 20;
		moneyValue.text = soldierMoney.ToString();
		yield return new WaitForSeconds (2f);
		subtractMoney.enabled = false;
		yield return null;
	}
/*
    IEnumerator DontShoot()
    {
        yield return new WaitForSeconds(1f);
        shootUp = false;
        yield return null;
    }
    */
	public void FindCubePos(Vector3 pos)
	{
		Vector3 temp=cameraPlay.GetComponent<Camera> ().WorldToScreenPoint (pos);
		temp= new Vector3(temp.x/1.7f,temp.y/1.5f,temp.z);
		//Debug.Log (temp);
		RemovePaintAt (temp);
	}

	void RemovePaintAt(Vector3 pos)
	{
		paintManager.GetComponent<PaintManager> ().CheckPaintAtPosition (pos);
	}
    public void GameOver()
    {

        gameOver = true;
		deathCount++;
        ammoCount = totalAmmo;
		soldierMoney = economyManager.GetComponent<EconomyManager> ().maxMoney;
		moneyValue.text = soldierMoney.ToString ();
        GetComponent<vp_SimpleCrosshair>().offsetX = 0.5f;
        GetComponent<vp_SimpleCrosshair>().offsetY = 0.5f;
        flashTexture.enabled = true;
		StartCoroutine ("WhiteScreen");
		//Instantiate (deathField, transform.position, Quaternion.identity);
		transform.position = new Vector3 (Random.Range (100f, 1600f), 390f, Random.Range (100f, 1600f));
		//gameOverText.text = "Game Over \n Press Tab to Play Again";
    }

    public void RestartGame()
    {
		terrainObj.GetComponent<TerrainToolkit> ().defaultTexture = tempTexture1;
        gameOverText.text = "";
        healthSlider.value = healthSlider.maxValue;
    }

	void OnDrawGizmosSelected() {
		p = cameraPlay.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0f,0f, cameraPlay.GetComponent<Camera>().nearClipPlane));
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(p, 0.1F);
		Gizmos.DrawLine(ray.origin,ray.direction*5f);
	}

	public void OffsetReticle()
	{
		if (GetComponent<vp_SimpleCrosshair> ().offsetX <= 1.0f) {
			if (Random.value < 0.5f)
				GetComponent<vp_SimpleCrosshair> ().offsetX += 0.1f;
			else
				GetComponent<vp_SimpleCrosshair> ().offsetX -= 0.1f;
		}
		if (GetComponent<vp_SimpleCrosshair> ().offsetY <=1.0f) {
			if (Random.value < 0.5f)
				GetComponent<vp_SimpleCrosshair> ().offsetY += 0.1f;
			else
				GetComponent<vp_SimpleCrosshair> ().offsetY -= 0.1f;	
		}
	}

	public void DamageEffect()
	{
		StartCoroutine ("DamageShow");
		playerSound.GetComponent<AudioSource> ().PlayOneShot (bulletHit);
	}

	IEnumerator DamageShow()
	{
        cameraPlay.GetComponent<PP_Negative> ().enabled = true;
        cameraPlay.GetComponent<VignetteAndChromaticAberration> ().enabled = true;
		yield return new WaitForSeconds (0.25f);
        cameraPlay.GetComponent<PP_Negative> ().enabled = false;
        cameraPlay.GetComponent<VignetteAndChromaticAberration> ().enabled = false;
		yield return null;
	}

	IEnumerator WhiteScreen()
	{
		for (float f=0f; f<10f; f+=0.01f) {
			flashTexture.color=Color.Lerp (Color.clear,Color.white,f/9f);
			//Debug.Log(f);
		}
		yield return new WaitForSeconds (2f);
		for (float m=0f; m<10f; m+=0.01f) {
			flashTexture.color= Color.Lerp (Color.white,Color.clear,m/9f);
			//Debug.Log(m);
		}
		yield return new WaitForSeconds (2f);

		gameOver = false;
		healthSlider.value = 100f;
		//flashTimer = 0f;
		whiteCam.SetActive (false);
        cameraPlay.SetActive (true);
		yield return null;
	}
}
