using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pulse")]
public class PP_Pulse : PostProcessBase {
	//Speed is speed
	//distance is obviously distance :)
	public float speed = 5f;
	public float distance = 0.1f;
	
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Pulse");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		//You would probably want to animate these
		//So, keep them here
		base.material.SetFloat("_Speed", speed);
		base.material.SetFloat("_Distance", distance);
		Graphics.Blit (source, destination, material);
	}
}