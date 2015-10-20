using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Wiggle")]
public class PP_Wiggle : PostProcessBase {
	/*How to use;
	With little variations of speed and amplitude you can have a drunk guy vision
	with double images..etc.
	Its also good for underwater effects
	*/
	
	//Speed and amplitude of Wiggles
	public float speed = 10.0f;
	public float amplitude = 0.01f;
	
	//If you want to animate speed and amplitude, you should move below
	//function calls to OnRenderImage
	void Awake () {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amplitude", amplitude);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Wiggle");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amplitude", amplitude);
		Graphics.Blit (source, destination, material);
	}
}