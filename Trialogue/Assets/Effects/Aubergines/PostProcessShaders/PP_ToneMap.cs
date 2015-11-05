using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ToneMap")]
public class PP_ToneMap : PostProcessBase {
	
	public float exposure = 0.1f;
	public float gamma = 1.0f;
	
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/ToneMap");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		//If you dont want to animate exposure and gamma, move them to Awake method
		base.material.SetFloat("_Exposure", exposure);
		base.material.SetFloat("_Gamma", gamma);
		Graphics.Blit (source, destination, material);
	}
}