using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Vignette")]
public class PP_Vignette : PostProcessBase {
	//Values should be between 0f and 1f
	//just play with them
	public float radius = 3f;
	public float darkness = 0.5f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Vignette");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Radius", radius);
		base.material.SetFloat("_Darkness", darkness);
		Graphics.Blit (source, destination, material);
	}
}