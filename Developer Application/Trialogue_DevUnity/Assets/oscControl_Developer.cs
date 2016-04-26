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
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class oscControl_Developer : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	public GameObject cube;
	public GameObject[] gameplaySet;
	public GameObject[] visualSet;
	public GameObject[] envSet;
	public GameObject[] enemySet;
	public GameObject[] youSet;
	public GameObject[] PRSet;
	public GameObject[] shootingSet;
	public GameObject metascoreLine;

	public GameObject waitScreenManager;

	public float timer=0f;
	private float boolVal=0f;
	public static int envID=0;
	// Script initialization
	void Start() {	
		OSCHandler_Developer.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
		MetascoreChanged (metascoreLine.GetComponent<Slider>());
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		OSCHandler_Developer.Instance.UpdateLogs();
		servers = OSCHandler_Developer.Instance.Servers;
		
	    foreach( KeyValuePair<string, ServerLog> item in servers )
		{
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if(item.Value.log.Count > 0) 
			{
				int lastPacketIndex = item.Value.packets.Count - 1;
//				
//				UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}", 
//				                                    item.Key, // Server name
//				                                    item.Value.packets[lastPacketIndex].Address, // OSC address
//				                                    item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value

				float tempVal = float.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());

				if (item.Value.packets[lastPacketIndex].Address == "/Dev/Metascore") //gameplay
				{
					metascoreLine.GetComponent<Slider>().value=tempVal;
					MetascoreChanged(metascoreLine.GetComponent<Slider>());
				}
				if (item.Value.packets [lastPacketIndex].Address == "/Player/Reset") { //player reset

					if (tempVal == 1) {
						EndScreenManager.timerTotal = timer;
						EndScreenManager.metaScoreTotal = (int)metascoreLine.GetComponent<Slider> ().value;
						OSCHandler_Developer.Instance.OnPlayerQuit ();
						SceneManager.LoadScene ("EndScreen");
						//waitScreenManager.GetComponent<WaitScreenManager> ().PlayerEntered ();
					}
				}
				if (item.Value.packets [lastPacketIndex].Address == "/Player/Entered") { //player reset

					if (tempVal == 1) {
						waitScreenManager.GetComponent<WaitScreenManager> ().PlayerEntered ();
					}
				}

			}
		}
		timer += Time.deltaTime;

	}

	void TurnOffElements(int temp,GameObject[] valueSet)
	{
		Debug.Log (temp);

		for (int i = 0; i < valueSet.Length; i++) {
			
			//turn off
			if (valueSet[i].gameObject.GetComponent<MetaManager>().metaLimit>=temp) {
				if (valueSet [i].gameObject.GetComponent<Slider> () != null)
					valueSet [i].gameObject.GetComponent<Slider> ().interactable = false;
				else if (valueSet [i].gameObject.GetComponent<bl_ToggleSwitcher> () != null)
					valueSet [i].gameObject.GetComponent<bl_ToggleSwitcher> ().interactable = false;

				valueSet [i].transform.parent.FindChild ("Text").gameObject.GetComponent<Text> ().color = Color.red;
			} else if (valueSet[i].gameObject.GetComponent<MetaManager>().metaLimit<temp) {
				if (valueSet [i].gameObject.GetComponent<Slider> () != null)
					valueSet [i].gameObject.GetComponent<Slider> ().interactable = true;
				else if (valueSet [i].gameObject.GetComponent<bl_ToggleSwitcher> () != null)
					valueSet [i].gameObject.GetComponent<bl_ToggleSwitcher> ().interactable = true;

				valueSet [i].transform.parent.FindChild ("Text").gameObject.GetComponent<Text> ().color = Color.white;
			}
		}
	}

	public void SendPR(GameObject obj)
	{
		string temp = obj.GetComponent<Text> ().text;
		Debug.Log (temp);
		OSCHandler_Developer.Instance.SendMessageToClient ("Critic", "/Critic/PressRelease", temp); 
	}

	public void MetascoreChanged(Slider metaSlider)
	{
		float value=metaSlider.value;
		int tempStr =(int) value / 10;
		Debug.Log (tempStr);

		TurnOffElements (tempStr,gameplaySet);
		TurnOffElements (tempStr,visualSet);
		TurnOffElements (tempStr,envSet);
		TurnOffElements (tempStr,enemySet);
		TurnOffElements (tempStr,youSet);

	}
	public void ChangeValue(String name)
	{
		//Debug.Log ("hi");
		Debug.Log (name);
		switch (name) {

			//gameplay set


		//10 pack

		//20 pack


		//10 pack

		//10 pack

		//10 pack

		//10 pack

		//10 pack

		//10 pack

		case "GameSpeed":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/GameSpeed", gameplaySet [0].GetComponent<Slider> ().value); 
			}
			break;
		case "ArtWeapon":
			if (metascoreLine.GetComponent<Slider> ().value > 90f) {
				if (gameplaySet [1].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/PaintItBlack", boolVal); 
			}
			break;
		case "NoGuns":
			if (metascoreLine.GetComponent<Slider> ().value > 10f) {
				if (gameplaySet [2].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/NoGuns", boolVal); 
			}
			break;
		case "HealthAmmo":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				if (gameplaySet [3].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/HealthAmmo", boolVal); 
			}
			break;
		case "RegenHealth":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				if (gameplaySet [4].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/RegenHealth", boolVal); 
			}
			break;
		case "Reticles":
			if (gameplaySet [5].GetComponent<bl_ToggleSwitcher> ().isOn) { //means multiple
				if (metascoreLine.GetComponent<Slider> ().value > 80f) {
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/MultipleReticles",1f);
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/NoReticles", 0f);
				}
			} else {
				if (metascoreLine.GetComponent<Slider> ().value > 70f) {
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/MultipleReticles",0f);
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/NoReticles", 1f); 
				}
			}
			break;
		case "JumpEnabled":
			if (metascoreLine.GetComponent<Slider> ().value > 50f) {
				if (gameplaySet [6].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/JumpEnabled", boolVal); 
			}
			break;
//		case "HeadSeparation":
//			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
//				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Gameplay/HeadSeparation", gameplaySet [8].GetComponent<Slider> ().value); 
//			}
//			break;
			

			//visuals set


//		case "DirLightIntensity":
//			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
//				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/DirLightIntensity", visualSet [0].GetComponent<Slider> ().value);
//			}
//			break;
		case "RedDir":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/RedDir", visualSet [1].GetComponent<Slider> ().value); 
			}
			break;
		case "BlueDir":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/BlueDir", visualSet [2].GetComponent<Slider> ().value); 
			}
			break;
		case "GreenDir":
			if (metascoreLine.GetComponent<Slider> ().value > 70f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/GreenDir", visualSet [3].GetComponent<Slider> ().value); 
			}
			break;
		case "DontClear":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				if (visualSet [4].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/DontClear", boolVal); 
			}
			break;
		case "InvertColors":
			if (metascoreLine.GetComponent<Slider> ().value > 70f) {
				if (visualSet [13].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/InvertColors", boolVal); 
			}
			break;
		case "2DCam":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				if (visualSet [5].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/2DCam", boolVal); 
			}
			break;
		case "CamFoV":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/CamFoV", visualSet [6].GetComponent<Slider> ().value); 
			}
			break;
		case "Pixelated":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				if (visualSet [7].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/Pixelated", boolVal); 
			}
			break;
//		case "Postered":
//			if (metascoreLine.GetComponent<Slider> ().value > 10f) {
//				if (visualSet [8].GetComponent<bl_ToggleSwitcher> ().isOn)
//					boolVal = 1f;
//				else
//					boolVal = 0f;
//				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/Postered", boolVal); 
//			}
//			break;
		case "Nightvision":
			if (metascoreLine.GetComponent<Slider> ().value > 60f) {
				if (visualSet [9].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/Nightvision", boolVal); 
			}
			break;
		case "Scanlines":
			if (metascoreLine.GetComponent<Slider> ().value > 80f) {
				if (visualSet [10].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/Scanlines", boolVal);
			}
			break;
		case "GroundWater":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				if (visualSet [11].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/GroundWater", boolVal);  
			}
			break;
//		case "UpsideDown":
//			if (metascoreLine.GetComponent<Slider> ().value > 60f) {
//				if (visualSet [12].GetComponent<bl_ToggleSwitcher> ().isOn)
//					boolVal = 1f;
//				else
//					boolVal = 0f;
//				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Visuals/UpsideDown", boolVal); 
//			}
//			break;


			//environment set


		case "GreenTrees":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				if (envSet [0].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Environment/GreenTrees", boolVal); 
			}
			break;
		case "TreeSize":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Environment/TreeSize", envSet [1].GetComponent<Slider> ().value); 
			}
			break;
		case "ConquerSpace":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
			if(envSet[2].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/ConquerSpace", boolVal); 
			}
			break;
//		case "BarrenLand":
//			if (metascoreLine.GetComponent<Slider> ().value > 0f) {
//				if (envSet [3].GetComponent<bl_ToggleSwitcher> ().isOn) {
//					boolVal = 1f;
//					envID = 1;
//				} else {
//					boolVal = 0f;
//					envID = 0;
//				}
//				OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/BarrenLand", boolVal); 
//			}
//			break;
		case "EnvType":
			if (metascoreLine.GetComponent<Slider> ().value >= 40f) {
				if(envSet[4].GetComponent<bl_ToggleSwitcher>().isOn)
				{
					boolVal=1f;
					envID = 2;
					OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/Battlefield", 1f); 
					OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/BattleArena", 0f);
				}
				else
				{
					boolVal=0f;
					envID = 0;
					OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/Battlefield", 0f); 
					OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/BattleArena", 1f);
				}

			}
			break;
//		case "Battlefield":
//			Debug.Log ("hi");	
//			if (metascoreLine.GetComponent<Slider> ().value >= 60f) {
//				if(envSet[5].GetComponent<bl_ToggleSwitcher>().isOn)
//				{
//					boolVal=1f;
//					envID = 3;
//				}
//				else
//				{
//					boolVal=0f;
//					envID = 0;
//				}
//				OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Environment/Battlefield", boolVal); 
//			}
//			break;
//
			//enemy set
		case "EnemySize":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/EnemySize", enemySet [2].GetComponent<Slider> ().value);
			}
			break;
		case "EnemyBehaviour":
			if (metascoreLine.GetComponent<Slider> ().value > 40f) {
				if (enemySet [1].GetComponent<bl_ToggleSwitcher> ().isOn) {
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/Aggressive", 1f); 
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/Peaceful", 0f); 
				}
				else
				{
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/Peaceful", 1f); 
					OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/Aggressive", 0f);
				}
			}

			break;
		case "DeadBodyRemains":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				if (enemySet [4].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/DeadBodyRemains", boolVal); 
			}
			break;
		case "DisableEnemies":
			if (metascoreLine.GetComponent<Slider> ().value > 80f) {
				if (enemySet [0].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/DisableEnemies", boolVal); 
			}
			break;
		case "EnemyType":
			if (metascoreLine.GetComponent<Slider> ().value > 50f) {
				if (enemySet [3].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Enemies/HumanEnemies", boolVal);
			}
			break;
	
		//you set

		case "NoDeath":
			if (metascoreLine.GetComponent<Slider> ().value > 20f) {
				if (youSet [0].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/NoDeath", boolVal); 
			}
			break;
		case "ShootToMove":
			if (metascoreLine.GetComponent<Slider> ().value > 80f) {
				if (youSet [1].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/ShootToMove", boolVal); 
			}
			break;
		case "YourHand":
			if (metascoreLine.GetComponent<Slider> ().value > 50f) {
				if (youSet [2].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/YourHand", boolVal); 
			}
			break;	
		case "MediaCoverage":
			if (metascoreLine.GetComponent<Slider> ().value > 80f) {
				if (youSet [3].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/MediaCoverage", boolVal); 
			}
			break;
		case "EnableLobbying":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				if (youSet [4].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/EnableLobbying", boolVal); 
			}
			break;
		case "PoliticalSpace":
			if (metascoreLine.GetComponent<Slider> ().value > 50f) {
				if (youSet [5].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/You/PoliticalSpace", boolVal); 
			}
			break;
			//shooting set
		case "SpawnsMore":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				if (shootingSet[0].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Shooting/SpawnsMore", boolVal); 
			}
			break;
		case "KillEnemy":
			if (metascoreLine.GetComponent<Slider> ().value > 50f) {
				if (shootingSet[1].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Shooting/KillEnemy", boolVal); 
			}
			break;
		case "ConvertEnemy":
			if (metascoreLine.GetComponent<Slider> ().value > 70f) {
				if (shootingSet [2].GetComponent<bl_ToggleSwitcher> ().isOn)
					boolVal = 1f;
				else
					boolVal = 0f;
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Shooting/ConvertEnemy", boolVal); 
			}
			break;
		case "ChangesSize":
			if (metascoreLine.GetComponent<Slider> ().value > 30f) {
				OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/Shooting/ChangesSize", shootingSet [3].GetComponent<Slider> ().value); 
			}
			break;
		

			
		}
		
	}
}