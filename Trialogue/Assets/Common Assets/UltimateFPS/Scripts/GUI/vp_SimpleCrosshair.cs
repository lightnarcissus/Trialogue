/////////////////////////////////////////////////////////////////////////////////
//
//	vp_SimpleCrosshair.cs
//	© VisionPunk. All Rights Reserved.
//	https://twitter.com/VisionPunk
//	http://www.visionpunk.com
//
//	description:	this script is just a stub for your own a way cooler crosshair
//					system. it simply draws a classic FPS crosshair center screen.
//
/////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections.Generic;

public class vp_SimpleCrosshair : MonoBehaviour
{

	// crosshair texture
	public Texture m_ImageCrosshair = null;
	public Texture crosshairTex;
	public Texture focusTex;
	public Texture crossTex;
	public float offsetX=0.5f;
	public float offsetY=0.5f;
	public int copies=1;
	public List<float> copyPos_X;
	public List<float> copyPos_Y;
	public bool overruleOffset=false;
	

	protected vp_FPPlayerEventHandler m_Player = null;
	
	
	protected virtual void Awake()
	{
		
		m_Player = GameObject.FindObjectOfType(typeof(vp_FPPlayerEventHandler)) as vp_FPPlayerEventHandler; // cache the player event handler
		
	}
	
	
	/// <summary>
	/// registers this component with the event handler (if any)
	/// </summary>
	protected virtual void OnEnable()
	{

		// allow this monobehaviour to talk to the player event handler
		if (m_Player != null)
			m_Player.Register(this);

	}


	/// <summary>
	/// unregisters this component from the event handler (if any)
	/// </summary>
	protected virtual void OnDisable()
	{

		// unregister this monobehaviour from the player event handler
		if (m_Player != null)
			m_Player.Unregister(this);

	}


	/// <summary>
	/// draws the crosshair texture smack in the middle of the screen
	/// </summary>
	void OnGUI()
	{
		if (RoleSwitcher.currentRole == 1) {
			if (!PlayerShoot.gameOver) {
				if (oscControl.noReticle) {
					m_ImageCrosshair = null;
				} else {
					m_ImageCrosshair = crosshairTex;
				}
				if (oscControl.allowMultipleReticle) {
					overruleOffset = true;
				} else {
					overruleOffset = false;
				}
			} 
			}
		else if (RoleSwitcher.currentRole == 2) {
            m_ImageCrosshair = null;
        } 
		else if (RoleSwitcher.currentRole == 3) {
			m_ImageCrosshair = focusTex;
			}
        else if(RoleSwitcher.currentRole==4)
        {
            m_ImageCrosshair = null;
        }
				if (m_ImageCrosshair != null) {
					GUI.color = new Color (1, 1, 1, 0.8f);

					if (!overruleOffset) {
						GUI.DrawTexture (new Rect ((Screen.width * (offsetX)) - (m_ImageCrosshair.width * 0.5f),
							(Screen.height * (1f - offsetY)) - (m_ImageCrosshair.height * 0.5f), m_ImageCrosshair.width,
							m_ImageCrosshair.height), m_ImageCrosshair);
						GUI.color = Color.white;
					} else {
						for (int i = 0; i < copies - 1; i++) {
							GUI.DrawTexture (new Rect ((Screen.width * (copyPos_X [i])) - (m_ImageCrosshair.width * 0.5f),
								(Screen.height * (1f - copyPos_Y [i])) - (m_ImageCrosshair.height * 0.5f), m_ImageCrosshair.width,
								m_ImageCrosshair.height), m_ImageCrosshair);
							GUI.color = Color.white;
						}
					}
				}
	
	}


	public void IncreaseCopies()
	{
		copies++;
		copyPos_X.Add(Random.Range (0f, 0.9f));
		copyPos_Y.Add(Random.Range (0f, 0.9f));

	}
	
	
	protected virtual Texture OnValue_Crosshair
	{
		get { return m_ImageCrosshair; }
		set { m_ImageCrosshair = value; }
	}
	

}

