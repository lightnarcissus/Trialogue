using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized; 
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	public GameObject pistol;
	private RaycastHit hit;
	public GameObject cube;
	private Ray ray;
	private Vector3 p;

	//cameras
	public GameObject whiteCam;
	public GameObject camera;

	public LayerMask mask=9;
	public List<AudioClip> weaponClips;
	public GameObject explosion;
	public GameObject pistolMuzzle;
	public Slider healthSlider;
	public GameObject oscManager;
	private float regenTimer=0f;
	public float regenRate=1f;
	private Vector3 muzzleSpawnPos = new Vector3 (0f, 0.16f, 0.7286987f);
    public Text gameOverText;
    public static bool gameOver = false;
	private GameObject tempMuzzle;

	public RawImage flashTexture;

	private float flashTimer=0f;
	// Use this for initialization
	void Start () {
		camera.GetComponent<Camera> ().enabled = false;
		camera.GetComponent<Camera> ().enabled = true;
		UnityEngine.Cursor.visible = false;
		Debug.Log ("Width: " + Screen.width / 2 + " and Height: " + Screen.height / 2);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			if (Input.GetMouseButtonDown (0)) {

				//Debug.Log ("shooting");
				ray = camera.GetComponent<Camera> ().ViewportPointToRay (new Vector3 (GetComponent<vp_SimpleCrosshair> ().offsetX, GetComponent<vp_SimpleCrosshair> ().offsetY, 0f));
				//ray=camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f,0f));
				pistol.GetComponent<Animator> ().Play ("PistolShoot");
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
				//Debug.DrawRay (ray.origin,ray.direction,Color.red);
				if (Physics.SphereCast (ray, 0.8f, out hit, 100f, mask.value)) {// Raycast(ray,out hit,mask.value))
					if (hit.collider.gameObject.tag == "Cube") {
						Destroy (hit.collider.gameObject);
						Instantiate (explosion, hit.collider.gameObject.transform.position, Quaternion.identity);
						OffsetReticle ();
					}
				}


			}
        

			if (healthSlider.value < 2) {
				healthSlider.value = 0;
				GameOver ();
			}
			regenTimer += Time.deltaTime;
			if (regenTimer * regenRate > 5f && oscManager.GetComponent<oscControl> ().regenHealth) {
				healthSlider.value++;
				regenTimer = 0f;
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
    public void GameOver()
    {
        gameOver = true;
		StartCoroutine ("WhiteScreen");
		//gameOverText.text = "Game Over \n Press Tab to Play Again";
    }

    public void RestartGame()
    {
        gameOverText.text = "";
        healthSlider.value = 100;
    }

	void OnDrawGizmosSelected() {
		p = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0f,0f, camera.GetComponent<Camera>().nearClipPlane));
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
		camera.SetActive (true);
		yield return null;
	}
}
