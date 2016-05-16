//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class oscControl : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private Dictionary<string, ClientLog> clients;
	private float randVal=0f;
    public GameObject directionalLight;
	public GameObject terrain;
	public Material waterMat;
    //objects
    public GameObject playerBody;
    public GameObject playerCamera;
    public GameObject treeSpawner;
    public static bool quit = false;

    public bool enableLobbying = false;
    //Environment page
    public bool greenTrees = false;
	public bool groundWater=false;
    public bool treeSpawn = false;
    public float treeSize = 1f;
    public float spawnRate=0.2f;
    public float spawnDistance=8f;
	public bool barrenLand=false;
	public bool battleArena=false;
	public bool battlefield=false;

	//Enemies page
	public float enemySpawnRate=0.1f;
	public bool enemySpawn=true;
	public bool humanEnemies=false;

	//platforms
	//public float platformSpawnRate=0.1f;
	//public bool platformSpawn=false;

    //Movement page
    public float gameSpeed = 1f;
    public bool upsideDown = false;
    public bool jumpEnabled = true;
    public float gravityMult = 1f;
    public float headSeparation = 0f;

    //Visuals page
    public float red = 1f;
    public float green = 1f;
    public float blue = 1f;
    public float lightIntensity = 1f;
    public float cameraFOV = 60f;
    public float cameraFarClip = 500f;
    public bool twoDimCam=false;
	public bool doNotClear=false;
    //public bool depthOnly=false;
    public bool negative=false;
    public bool scanlines=false;
    public bool postered=false;
    public bool scratches=false;
    public bool pixelated=false;
	public bool nightVision=false;
    public bool charcoal=false;
    private bool reset =true;
	public bool regenHealth=false;
	public bool healthAmmo = false;
	public bool noGuns=false;
	public bool paintAllow = false;

	private bool headlineFlashing=false;

	public EconomyManager economyManager;

	//Enemy page
	public bool killEnemy = false;
	public bool convertEnemy=false;
	public bool spawnsMore=false;
	public bool deadBodyRemains=false;


	//you page

	public bool mediaCensorship = false;
	public bool unlimitedPublicFunds=false;

    //critic
    public Text headlineText;
    public float gameplay = 0f;
    private bool disableComplexGameplay = false;

    public float graphics = 0f;
    private bool disableFancyGraphics = false;

    public float audioGame = 0f;
    private bool disableJazzyAudio = false;

    public float value = 0f;
    private bool disableDifficultThings = false;
    public OSCHandler oscHandler;
    public float overall = 0f;

    //head separation distance
    //camera out of sync
    //enemy collider out of sync
    //reticle Spread
    public static bool allowMultipleReticle = false;
	public static bool noReticle=false;
	private bool devEntered=false;
	public GameObject ephemeral;
	public GameObject enemyGroup;
	public GameObject telepoleManager;
    /// <summary>
 
    /// </summary>

	private String msg="";
	// Script initialization
	void Start() {	
		Cursor.visible = false;
		OSCHandler.Instance.Init(); //init OSC
         //OSCHandler.Instance.OnPlayerQuit();
      //  oscHandler = OSCHandler.Instance();
		servers = new Dictionary<string, ServerLog>();
		clients = new Dictionary<string,ClientLog> ();
        servers = OSCHandler.Instance.Servers;
        clients = OSCHandler.Instance.Clients;
      //  ResetAll();

		//initiator message
//		OSCHandler.Instance.SendMessageToClient("localhost", "blah",2f);

        //updating Designer device
//        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Environment/fader3",spawnDistance); // tree spawn distance
//        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Environment/fader4", spawnRate); // tree spawn rate
//        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Environment/fader2", treeSize); // tree size
        

        //updating Artist device
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/GreenDir", 1f); //green
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/BlueDir", 1f);//blue
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/RedDir", 1f);//red
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/DirLightIntensity", directionalLight.GetComponent<Light>().intensity); //intensity
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/CamFoV", playerCamera.GetComponent<Camera>().fieldOfView); //fov
//        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/fader5", playerCamera.GetComponent<Camera>().farClipPlane); //far clip
//		OSCHandler.Instance.SendMessageToClient("iPad Client", "/Enemies/Aggressive", 1f); //set aggressive to true
//		OSCHandler.Instance.SendMessageToClient("iPad Client", "/Movement/rotary1", 1f); //game speed
//		OSCHandler.Instance.SendMessageToClient("iPad Client", "/Movement/fader6", gravityMult); //gravity multiplier

	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		if (!devEntered && StartManager.start) {
			OSCHandler.Instance.SendMessageToClient ("Max", "/Player/Entered", 1f);

		}
		OSCHandler.Instance.UpdateLogs();
		if (quit) {
			OSCHandler.Instance.SendMessageToClient ("Max", "/Player/Reset", 1f);
			ephemeral.GetComponent<DestroyEphemeral> ().DestroySpawn ();
			enemyGroup.GetComponent<DestroyEphemeral> ().DestroySpawn ();
		//	telepoleManager.GetComponent<DestroyEphemeral> ().DestroySpawn ();
			economyManager.Reset ();
			playerBody.GetComponent<PlayerShoot> ().Reset ();
			quit = false;
		//	OSCHandler.Instance.OnPlayerQuit ();
		}
//		if (UnityEngine.Random.value < 0.3f) {
//			randVal = UnityEngine.Random.Range (0f, 0.7f);
//			//OSCHandler.Instance.SendMessageToClient ("iPad Client", "/Visuals/fader2", 8f);
//		}
		//OSCHandler.Instance.UpdateLogs();

		foreach (KeyValuePair<string, ServerLog> item in servers) {
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if (item.Value.log.Count > 0) {
				int lastPacketIndex = item.Value.packets.Count - 1;
				int beforeLastPacketIndex= item.Value.packets.Count-2;
					
			/*	UnityEngine.Debug.Log (String.Format ("SERVER: {0} ADDRESS: {1} VALUE : {2}", 
					                                    item.Key, // Server name
					                                    item.Value.packets [lastPacketIndex].Address, // OSC address
					                                    item.Value.packets [lastPacketIndex].Data [0].ToString ())); //First data value
				*/	
//				Debug.Log ("last one: "+item.Value.packets[lastPacketIndex].Address);
//				Debug.Log ("one before that: "+item.Value.packets[beforeLastPacketIndex].Address);
				//{
				string tempString="";
				float tempVal = 0f;
				if(item.Value.packets [lastPacketIndex].Address =="/Critic/Headline")
					tempString= item.Value.packets[lastPacketIndex].Data[0].ToString();
				else
					tempVal= float.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());
            //    Debug.Log(item.Value.packets [lastPacketIndex].Address.ToString());
                //critic section begins
				if (item.Value.packets [lastPacketIndex].Address == "/critic/fader1") { //gameplay
					if (tempVal > 8) {
						disableComplexGameplay = false;
						/*  lightIntensity = 1.5f;
                          OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/fader2", lightIntensity);
                          directionalLight.GetComponent<Light>().intensity = lightIntensity;
                          //OSCHandler.Instance.UpdateLogs(); */
					} else {
						disableComplexGameplay = false;
					}
				}
                /*
                else if (item.Value.packets[lastPacketIndex].Address == "/critic/fader3") //graphics
                {
                    if (tempVal > 8)
                    {
                        disableFancyGraphics = false;
                    }
                    else
                    {
                        disableFancyGraphics = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/critic/fader4") //audio
                {
                    if (tempVal > 8)
                    {
                        disableJazzyAudio = false;
                    }
                    else
                    {
                        disableJazzyAudio = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/critic/fader2") //value
                {
                    if (tempVal > 8)
                    {
                        disableDifficultThings = false;
                    }
                    else
                    {
                        disableDifficultThings = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/critic/fader6") //overall
                {
                    //for future use
                }
                */
				else if (item.Value.packets [lastPacketIndex].Address == "/Developer/Entered") {
					if (tempVal == 1)
						devEntered = true;
					else
						devEntered = false;
				}
                else if (item.Value.packets [lastPacketIndex].Address == "/Environment/GreenTrees") { //green trees?
					if (tempVal == 0)
						greenTrees = false;
					else
						greenTrees = true;

				} else if (item.Value.packets [lastPacketIndex].Address == "/Environment/BarrenLand") { //green trees?
					if (tempVal == 0) {
						barrenLand = false;
						SettleOnTerrain.terrainStatus = 0;
					} else {
						barrenLand = true;
						SettleOnTerrain.terrainStatus = 1;
					}

				}
                else if (item.Value.packets[lastPacketIndex].Address == "/Environment/BattleArena") //green trees?
                {
                    //playerBody.GetComponent<AudioSource>().clip=
                    if (tempVal == 0)
                    {
                        battleArena = false;
                        SettleOnTerrain.terrainStatus = 0;
                    }
                    else
                    {
                        battleArena = true;
                        SettleOnTerrain.terrainStatus = 2;
                    }

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Environment/Battlefield") //green trees?
                {
                    Debug.Log(tempVal);
                    if (tempVal == 0)
                    {
                        battlefield = false;
                        SettleOnTerrain.terrainStatus = 0;
                    }
                    else
                    {
                        Debug.Log("battlefield activated");
                        battlefield = true;
                        SettleOnTerrain.terrainStatus = 3;
                    }

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/GroundWater") //ground is water?
                {
                    //Debug.Log("innit");
                    if (tempVal == 0)
                    {
                        groundWater = false;
                        terrain.GetComponent<Terrain>().materialType = Terrain.MaterialType.BuiltInStandard;

                    }
                    else
                    {
                        //Debug.Log("YAY innit");
                        groundWater = true;
                        terrain.GetComponent<Terrain>().materialType = Terrain.MaterialType.Custom;
                        terrain.GetComponent<Terrain>().materialTemplate = waterMat;
                    }

                }

                else if (item.Value.packets[lastPacketIndex].Address == "/Environment/TreeSize") //tree size
                {
                    treeSize = tempVal;
                }

                //				else if (item.Value.packets[lastPacketIndex].Address == "/Environment/fader11") //trees spawn distance
                //                {
                //                    spawnDistance = tempVal;
                //                }
                //				else if (item.Value.packets[lastPacketIndex].Address == "/Environment/fader12") //trees spawn rate
                //                {
                //                    spawnRate = tempVal;
                //                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/GameSpeed") //game speed
                {
                    gameSpeed = tempVal;
                    Time.timeScale = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/JumpEnabled") //jump enabled?
                {
                    if (tempVal == 0)
                    {

                        jumpEnabled = false;
                        playerBody.GetComponent<FirstPersonController>().m_JumpSpeed = 0f;
                    }
                    else
                    {
                        playerBody.GetComponent<FirstPersonController>().m_JumpSpeed = 10f;
                        jumpEnabled = true;
                    }
                    Debug.Log("Jump is " + jumpEnabled);

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/UpsideDown") //upside down?
                {
                    if (tempVal == 0)
                    {
                        upsideDown = false;
                        playerCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    }
                    else
                    {
                        upsideDown = true;
                        playerCamera.transform.eulerAngles = new Vector3(0f, 0f, -180f);
                    }

                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/fader6") //gravity multiplier
                //                {
                //                    gravityMult = tempVal;
                //                    Physics.gravity *= tempVal;
                //
                //                }
                //				else if(item.Value.packets [lastPacketIndex].Address=="/Visuals/PaintItBlack") //paint it black?
                //				{
                //					//Debug.Log("innit");
                //					if (tempVal==0)
                //					{
                //						//groundWater=false;
                //						playerBody.GetComponent<PlayerShoot>().paintAllow=false;
                //						
                //					}
                //					else
                //					{
                //						//Debug.Log("YAY innit");
                //						playerBody.GetComponent<PlayerShoot>().paintAllow=true;
                //					
                //					}
                //				}
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/HeadSeparation") //head separation distance
                {
                    headSeparation = tempVal;
                    playerCamera.transform.localPosition = new Vector3(tempVal, tempVal, tempVal);


                }

                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/RegenHealth") //regenerating health?
                {
                    if (tempVal == 1)
                        regenHealth = true;
                    else
                        regenHealth = false;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/HealthAmmo") //health == ammo?
                {
                    if (tempVal == 1)
                        healthAmmo = true;
                    else
                        healthAmmo = false;
                }
                //				else if (item.Value.packets[lastPacketIndex].Address == "/Health/fader8") //regen rate
                //				{
                //					playerBody.GetComponent<PlayerShoot>().regenRate=tempVal;
                //				}
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/MultipleReticles") //allow multiple reticles
                {
                    if (tempVal == 1)
                        allowMultipleReticle = true;
                    else
                        allowMultipleReticle = false;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/NoReticles") //no reticles
                {
                    if (tempVal == 1)
                        noReticle = true;
                    else
                        noReticle = false;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/NoGuns") //no guns?
                {
                    if (tempVal == 0)
                    {
                        noGuns = true;
                        playerCamera.transform.FindChild("Pistol").gameObject.SetActive(false);
                        playerBody.GetComponent<PlayerShoot>().enabled = false;
                        playerBody.GetComponent<vp_SimpleCrosshair>().enabled = false;
                    }
                    else
                    {
                        noGuns = false;
                        playerCamera.transform.FindChild("Pistol").gameObject.SetActive(true);
                        playerBody.GetComponent<PlayerShoot>().enabled = true;
                        playerBody.GetComponent<vp_SimpleCrosshair>().enabled = true;
                    }
                    //	Debug.Log(noGuns);
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Gameplay/PaintItBlack") //paint brush
                {
                    if (tempVal == 1)
                    {
                        paintAllow = true;
                        playerBody.GetComponent<PlayerShoot>().paintAllow = true;
                        //playerBody.GetComponent<vp_SimpleCrosshair>().enabled = false;
                    }
                    else
                    {
                        paintAllow = false;
                        playerBody.GetComponent<PlayerShoot>().paintAllow = false;
                        //playerBody.GetComponent<vp_SimpleCrosshair>().enabled = true;
                    }
                  //  Debug.Log(paintAllow);
                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Health/rotary5") //enemy collision out of sync x
                //                {
                //                    Aggressive.colX = tempVal;
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Health/rotary6") //enemy collision out of sync y
                //                {
                //                    Aggressive.colY = tempVal;
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Health/rotary7") //enemy collision out of sync z
                //                {
                //                    Aggressive.colZ = tempVal;
                //                }

                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/RedDir") //red
                {
                    red = tempVal;
                    playerCamera.GetComponent<PP_Charcoal>().lineColor= new Color(red, green, blue, 1f);
                    //directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/GreenDir") //green
                {
                    green = tempVal;
                    playerCamera.GetComponent<PP_Charcoal>().lineColor = new Color(red, green, blue, 1f);
                    //directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/BlueDir") //blue
                {
                    blue = tempVal;
                    playerCamera.GetComponent<PP_Charcoal>().lineColor = new Color(red, green, blue, 1f);
                  //  directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/DirLightIntensity") //intensity
                {
                    Debug.Log(tempVal);
                    lightIntensity = tempVal;
                    directionalLight.GetComponent<Light>().intensity = lightIntensity;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/CamFoV") //fov
                {
                    cameraFOV = tempVal;
                    playerCamera.GetComponent<Camera>().fieldOfView = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/fader5") //far clip plane
                {
                    cameraFarClip = tempVal;
                    playerCamera.GetComponent<Camera>().farClipPlane = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/2DCam") //2D Camera?
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<Camera>().orthographic = false;
                        twoDimCam = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<Camera>().orthographic = true;
                        twoDimCam = true;
                    }
                }
                else if(item.Value.packets[lastPacketIndex].Address == "/Visuals/InvertColors") //invert colors
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<PP_Negative>().enabled = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_Negative>().enabled = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/DontClear") //don't clear?
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
                        doNotClear = false;
                    }
                    else
                    {
                        doNotClear = true;
                        playerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
                    }
                }

				//you page

				else if (item.Value.packets[lastPacketIndex].Address == "/You/MediaCoverage") //media censorship?
				{
					if (tempVal == 0)
					{
						mediaCensorship = false;
					}
					else
					{
						mediaCensorship = true;
					}
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/You/PoliticalSpace") //media censorship?
				{
					if (tempVal == 0)
					{
						unlimitedPublicFunds = false;
					}
					else
					{
						unlimitedPublicFunds = true;
					}
				}
                else if (item.Value.packets[lastPacketIndex].Address == "/You/EnableLobbying") //media censorship?
                {
                    if (tempVal == 0)
                    {
                        enableLobbying = false;
                    }
                    else
                    {
                        enableLobbying = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Critic/Headline") //critic messages
                {
                    headlineText.text = tempString;
					if(!headlineFlashing)
					StartCoroutine ("FlashHeadline");
                }
                /*   else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle2") //Depth Only?
                   {
                       if(tempVal==0)
                       {
                           playerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
                           depthOnly = false;
                       }
                       else
                       {
                           playerCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
                           depthOnly = true;
                       }
                   }
                 */
                /*   else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle3" && !disableFancyGraphics) //Negative?
                   {
                       if (tempVal == 0)
                       {
                           playerCamera.GetComponent<PP_Negative>().enabled = false;
                           negative = false;
                       }
                       else
                       {
                           playerCamera.GetComponent<PP_Negative>().enabled = true;
                           negative = true;

                       }
                   }*/
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/Scanlines") //Scanlines?
                {

                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<PP_SecurityCamera>().enabled = false;
                        scanlines = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_SecurityCamera>().enabled = true;
                        scanlines = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/Postered") //Postered?
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<PP_4Bit>().enabled = false;
                        postered = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_4Bit>().enabled = true;
                        postered = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/Pixelated") //Pixelated?
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<PP_Pixelated>().enabled = false;
                        pixelated = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_Pixelated>().enabled = true;
                        pixelated = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/Nightvision") //night vision?
                {
                    if (tempVal == 0)
                    {
                        playerCamera.GetComponent<PP_NightVisionV2>().enabled = false;
                        nightVision = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_NightVisionV2>().enabled = true;
                        nightVision = true;
                    }
                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle7") //Scratches?
                //                {
                //                    if (tempVal == 0)
                //                    {
                //                        playerCamera.GetComponent<PP_Scratch>().enabled = false;
                //                        scratches = false;
                //                    }
                //                    else
                //                    {
                //                        playerCamera.GetComponent<PP_Scratch>().enabled = true;
                //                        scratches = true;
                //
                //                    }
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle8") //Charcoal?
                //                {
                //                    if (tempVal == 0)
                //                    {
                //                        playerCamera.GetComponent<PP_Charcoal>().enabled = false;
                //                        charcoal = false;
                //                    }
                //                    else
                //                    {
                //                        playerCamera.GetComponent<PP_Charcoal>().enabled = true;
                //                        charcoal = true;
                //                    }
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Camera/rotary5") //camera out of sync on x
                //                {
                //                    playerCamera.transform.localEulerAngles = new Vector3(tempVal, playerCamera.transform.localEulerAngles.y, playerCamera.transform.localEulerAngles.z);
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Camera/rotary6") //camera out of sync on y
                //                {
                //                    playerCamera.transform.localEulerAngles = new Vector3(playerCamera.transform.localEulerAngles.x, tempVal, playerCamera.transform.localEulerAngles.z);
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Camera/rotary9") //camera out of sync on z
                //                {
                //                    playerCamera.transform.localEulerAngles = new Vector3(playerCamera.transform.localEulerAngles.x, playerCamera.transform.localEulerAngles.y, tempVal);
                //                }
                //
                //                else if(item.Value.packets[lastPacketIndex].Address == "/Enemy/rotary14") //enemy size X
                //                 {
                //                    CubeManager.globalSizeX = tempVal;
                //                 }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Enemy/rotary15") //enemy size Y
                //                {
                //                    CubeManager.globalSizeY = tempVal;
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Enemy/rotary16") //enemy size Z
                //                {
                //                    CubeManager.globalSizeZ = tempVal;
                //                }
                //                else if (item.Value.packets[lastPacketIndex].Address == "/Enemy/fader8") //enemy speed
                //                {
                //                    CubeManager.globalSpeed = tempVal;
                //                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/Peaceful") //allow passive
                {
                    if (tempVal == 0)
                        CubeManager.aggressiveActive = true;
                    else
                        CubeManager.aggressiveActive = false;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/KillEnemy") //allow aggressive
                {
                    if (tempVal == 0)
                    {
                        CubeManager.killCube = false;
                        killEnemy = false;
                    }
                    else
                    {
                        CubeManager.killCube = true;
                        killEnemy = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/ConvertEnemy") //allow aggressive
                {
                    if (tempVal == 0)
                    {
                        convertEnemy = false;
                        CubeManager.convertCube = false;
                    }
                    else
                    {
                        convertEnemy = true;
                        CubeManager.convertCube = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/SpawnsMore") //allow aggressive
                {
                    if (tempVal == 0)
                    {
                        spawnsMore = true;
                        CubeManager.spawnsMore = false;
                    }
                    else
                    {
                        CubeManager.spawnsMore = true;
                        spawnsMore = true;
                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/Aggressive") //allow aggressive
                {
                    if (tempVal == 0)
                        CubeManager.aggressiveActive = false;
                    else
                        CubeManager.aggressiveActive = true;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/EnemySize") //allow aggressive
                {
                    CubeManager.globalSize = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/DisableEnemies") //disable all enemies
                {
					if (tempVal == 0)
						enemyGroup.GetComponent<EnemyGroupManager> ().DisableEnemies ();
                    else
						enemyGroup.GetComponent<EnemyGroupManager> ().EnableEnemies();

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/DeadBodyRemains") //disable all enemies
                {
                    if (tempVal == 1)
                    {
                        CubeManager.bodyRemains = true;
                        deadBodyRemains = true;

                    }
                    else
                    {
                        CubeManager.bodyRemains = false;
                        deadBodyRemains = false;
                    }


                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Enemies/HumanEnemies") //disable all enemies
                {
                    if (tempVal == 1)
                    {
                        CubeManager.humanEnemies = true;
                        humanEnemies = true;

                    }
                    else
                    {
                        CubeManager.humanEnemies = false;
                        humanEnemies = false;
                    }


                }
                //	}
                //cube.transform.localScale = new Vector3 (tempVal, tempVal, tempVal);
            }
            
		}
			

		foreach( KeyValuePair<string, ClientLog> item in clients )
		{
			// If we have sent at least one message,
			// show the last sent message from the log in the Debug console
			if(item.Value.log.Count > 0) 
			{
				int lastMessageIndex = item.Value.messages.Count- 1;
				
//				UnityEngine.Debug.Log(String.Format("CLIENT: {0} ADDRESS: {1} VALUE 0: {2}", 
//				                                    item.Key, // Server name
//				                                    item.Value.messages[lastMessageIndex].Address, // OSC address
//				                                    item.Value.messages[lastMessageIndex].Data[0].ToString())); //First data value
//				                                    
			}

		}
	}

    void ResetAll()
    {
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/GameSpeed", 1f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/PaintItBlack", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/NoGuns", 1f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/HealthAmmo", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/RegenHealth",0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Gameplay/JumpEnabled", 1f);

        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/CamFoV", 60f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/GroundWater", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/Pixelated", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/NightVision", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/Scanlines", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/DontClear", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/2DCam", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/Graphics/InvertColors", 0f);


        OSCHandler.Instance.SendMessageToClient("Max,", "/You/EnableLobbying", 1f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/You/MediaCoverage", 0f);
        OSCHandler.Instance.SendMessageToClient("Max,", "/You/PoliticalSpace", 0f);
    }

	IEnumerator FlashHeadline()
	{
		headlineText.enabled = true;
		headlineFlashing = true;
		yield return new WaitForSeconds (10f);
		headlineFlashing = false;
		headlineText.enabled = false;
		yield return null;
	}
 
    
}