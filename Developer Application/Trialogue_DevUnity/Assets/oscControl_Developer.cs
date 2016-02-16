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

public class oscControl_Developer : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	public GameObject cube;
	public GameObject[] gameplaySet;
	public GameObject[] visualSet;
	public GameObject[] environmentSet;
	public GameObject[] enemySet;
	private float boolVal=0f;
	// Script initialization
	void Start() {	
		OSCHandler_Developer.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
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
				if (item.Value.packets[lastPacketIndex].Address == "/critic/fader1") //gameplay
				{
					if(tempVal > 4)
					{
						cube.GetComponent<Renderer>().material.color=Color.green;
					}
					else{
						cube.GetComponent<Renderer>().material.color=Color.red;
					}
				}
			}
	    }
	}
	public void ChangeValue(String name)
	{
		switch (name) {
			
		case "DirLightIntensity":
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/DirLightIntensity",visualSet[0].GetComponent<Slider>().value); 
			break;
		case "RedDir":
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/RedDir", visualSet[1].GetComponent<Slider>().value); 
			break;
		case "BlueDir":
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/BlueDir", visualSet[2].GetComponent<Slider>().value); 
			break;
		case "GreenDir":
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/GreenDir", visualSet[3].GetComponent<Slider>().value); 
			break;
		case "DontClear":
			if(visualSet[4].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/DontClear", boolVal); 
			break;
		case "2DCam":
			if(visualSet[5].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/2DCam", boolVal); 
			break;
		case "CamFoV":
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/CamFoV", visualSet[6].GetComponent<Slider>().value); 
			break;
		case "Pixelated":
			if(visualSet[7].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/Pixelated", boolVal); 
			break;
		case "Postered":
			if(visualSet[8].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/Postered", boolVal); 
			break;
		case "Nightvision":
			if(visualSet[9].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/Nightvision", boolVal); 
			break;
		case "Scanlines":
			if(visualSet[10].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/Scanlines", boolVal); 
			break;
		case "GroundWater":
			if(visualSet[11].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/GroundWater", boolVal);  
			break;
		case "UpsideDown":
			if(visualSet[12].GetComponent<bl_ToggleSwitcher>().isOn)
				boolVal=1f;
			else
				boolVal=0f;
			OSCHandler_Developer.Instance.SendMessageToClient("Max", "/Visuals/UpsideDown", boolVal); 
			break;
			
		}
		
	}
}