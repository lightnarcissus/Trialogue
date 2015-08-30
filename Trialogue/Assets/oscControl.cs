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

public class oscControl : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private Dictionary<string, ClientLog> clients;
	private float randVal=0f;
    public GameObject directionalLight;

    //objects
    public GameObject playerBody;
    public GameObject playerCamera;
    public GameObject treeSpawner;

    //Trees page
    public bool greenTrees = false;
    public float treeSize = 1f;
    public float spawnRate=0.2f;
    public float spawnDistance=8f;

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
    public bool depthOnly=false;
    public bool negative=false;
    public bool scanlines=false;
    public bool postered=false;
    public bool scratches=false;
    public bool pixelated=false;
    public bool charcoal=false;
    private bool reset =true;
	private String msg="";
	// Script initialization
	void Start() {	
		OSCHandler.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
		clients = new Dictionary<string,ClientLog> ();
        servers = OSCHandler.Instance.Servers;
        clients = OSCHandler.Instance.Clients;

        //updating Designer device
        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Trees/fader3",spawnDistance); // tree spawn distance
        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Trees/fader4", spawnRate); // tree spawn rate
        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Trees/fader2", treeSize); // tree size
        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Movement/rotary1", gameSpeed); //game speed
        OSCHandler.Instance.SendMessageToClient("iPhone5S Client", "/Movement/fader6", gravityMult); //gravity multiplier

        //updating Artist device
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/rotary2", 1f); //green
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/rotary3", 1f);//blue
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/rotary4", 1f);//red
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/fader2", directionalLight.GetComponent<Light>().intensity); //intensity
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/fader3", playerCamera.GetComponent<Camera>().fieldOfView); //fov
        OSCHandler.Instance.SendMessageToClient("iPad Client", "/Visuals/fader5", playerCamera.GetComponent<Camera>().farClipPlane); //far clip

		OSCHandler.Instance.UpdateLogs();
        
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		
		OSCHandler.Instance.UpdateLogs();
		if (UnityEngine.Random.value < 0.01f) {
			randVal = UnityEngine.Random.Range (0f, 0.7f);
			//OSCHandler.Instance.SendMessageToClient ("TouchOSC Bridge", "/Shield/fader3", randVal);
		}
		OSCHandler.Instance.UpdateLogs();

		foreach (KeyValuePair<string, ServerLog> item in servers) {
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if (item.Value.log.Count > 0) {
				int lastPacketIndex = item.Value.packets.Count - 1;
					
			/*	UnityEngine.Debug.Log (String.Format ("SERVER: {0} ADDRESS: {1} VALUE : {2}", 
					                                    item.Key, // Server name
					                                    item.Value.packets [lastPacketIndex].Address, // OSC address
					                                    item.Value.packets [lastPacketIndex].Data [0].ToString ())); //First data value
				*/	

				float tempVal = float.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());
                if(item.Value.packets [lastPacketIndex].Address=="/Trees/toggle1") //green trees?
                {
                    if (greenTrees)
                        greenTrees = false;
                    else
                        greenTrees = true;

                }
                else if(item.Value.packets [lastPacketIndex].Address=="/Trees/fader2") //tree size
                {
                    treeSize = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Trees/fader3") //trees spawn distance
                {
                    spawnDistance = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Trees/fader4") //trees spawn rate
                {
                    spawnRate = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/rotary1") //game speed
                {
                    gameSpeed = tempVal;
                    Time.timeScale = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/toggle2") //jump enabled?
                {
                    if (jumpEnabled)
                    {
                        Physics.gravity = new Vector3(0f, -98000f, 0f);
                        jumpEnabled=false;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.8f, 0f);
                        jumpEnabled = true;
                    }
                        
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/toggle3") //upside down?
                {
                    if (upsideDown)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/fader6") //gravity multiplier
                {
                    gravityMult = tempVal;
                    Physics.gravity *= tempVal;

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Movement/fader7") //head separation distance
                {
                    headSeparation = tempVal;
                    playerCamera.transform.position = new Vector3(tempVal, tempVal, tempVal);

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/rotary4") //red
                {
                    red = tempVal;
                    directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/rotary2") //green
                {
                    green = tempVal;
                    directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/rotary3") //blue
                {
                    blue= tempVal;
                    directionalLight.GetComponent<Light>().color = new Color(red, green, blue, 1f);

                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/fader2") //intensity
                {
                    lightIntensity = tempVal;
                    directionalLight.GetComponent<Light>().intensity = lightIntensity;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/fader3") //fov
                {
                    cameraFOV = tempVal;
                    playerCamera.GetComponent<Camera>().fieldOfView = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/fader5") //far clip plane
                {
                    cameraFarClip = tempVal;
                    playerCamera.GetComponent<Camera>().farClipPlane = tempVal;
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle1") //2D Camera?
                {
                    if (twoDimCam)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle2") //Depth Only?
                {
                    if(depthOnly)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle3") //Negative?
                {
                    if (negative)
                    {
                        playerCamera.GetComponent<PP_Negative>().enabled = false;
                        negative = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_Negative>().enabled =true;
                        negative = true;

                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle4") //Scanlines?
                {

                    if (scanlines)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle5") //Postered?
                {
                    if (postered)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle9") //Pixelated?
                {
                    if (pixelated)
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
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle7") //Scratches?
                {
                    if (scratches)
                    {
                        playerCamera.GetComponent<PP_Scratch>().enabled = false;
                        scratches = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_Scratch>().enabled = true;
                        scratches = true;

                    }
                }
                else if (item.Value.packets[lastPacketIndex].Address == "/Visuals/toggle8") //Charcoal?
                {
                    if (charcoal)
                    {
                        playerCamera.GetComponent<PP_Charcoal>().enabled = false;
                        charcoal = false;
                    }
                    else
                    {
                        playerCamera.GetComponent<PP_Charcoal>().enabled = true;
                        charcoal = true;
                    }
                }
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
				
				UnityEngine.Debug.Log(String.Format("CLIENT: {0} ADDRESS: {1} VALUE 0: {2}", 
				                                    item.Key, // Server name
				                                    item.Value.messages[lastMessageIndex].Address, // OSC address
				                                    item.Value.messages[lastMessageIndex].Data[0].ToString())); //First data value
				                                    
			}

		}
	}
 
    
}