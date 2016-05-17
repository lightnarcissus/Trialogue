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

public class oscControl_Critic : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private float boolVal=0f;
    public Slider overall;
    private float overallScore = 0f;
    public List<string> prStrings;
    public InputField headline;
    public string headlineText = "";
	public GameObject prGroup;
    private float tempVal= 0f;
    private string tempString = "";
    private string prevString = "";
	public Slider gameplay;
	public Slider graphics;
	public Slider audio;
	public Slider value;
    public GameObject prText;
	// Script initialization
	void Start() {	
		OSCHandler_Critic.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
//		MetascoreChanged (metascoreLine.GetComponent<Slider>());
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		OSCHandler_Critic.Instance.UpdateLogs();
		servers = OSCHandler_Critic.Instance.Servers;
		
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
                if (item.Value.packets[lastPacketIndex].Address == "/Critic/PressRelease")
                    tempString = item.Value.packets[lastPacketIndex].Data[0].ToString();
                else
                    tempVal = float.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());
                 
				if (item.Value.packets [lastPacketIndex].Address == "/Critic/Reset") { //gameplay
					prGroup.GetComponent<PRManager>().Clear();
				}
                if (item.Value.packets[lastPacketIndex].Address == "/Critic/PressRelease") //gameplay
				{
                    if(tempString!=prevString)
                    { 
                    GameObject tempObj;
                        string[] tempArray;
                        tempArray=tempString.Split(" "[ 0]); 
                        for(int i=0;i<tempArray.Length;i++)
                        {
                            tempObj = Instantiate(prText, Vector3.zero, Quaternion.identity) as GameObject;
                            tempObj.GetComponent<TextMesh>().text = tempArray[i];
							tempObj.transform.parent = prGroup.transform;
                        }
                          
                    prevString = tempString;
                    }
                }
                
			}
		}
	}
	public void SliderChanged()
    {
		overallScore = ((overall.value * 0.4f) +(gameplay.value * 0.2f) + (graphics.value * 0.2f) + (audio.value * 0.1f) + (value.value*0.1f)) * 10f;
		overall.value = overallScore / 10f;
		Debug.Log (overallScore);
        OSCHandler_Critic.Instance.SendMessageToClient("Developer", "/Dev/Metascore", overallScore);
      //  Debug.Log("sending message to " + ListIP.otherIPAddress);
    }

    public void HeadlineChanged()
    {
        Debug.Log("changed");
        headlineText = headline.text;
        OSCHandler_Critic.Instance.SendMessageToClient("Player", "/Critic/Headline", headlineText);
    }
}