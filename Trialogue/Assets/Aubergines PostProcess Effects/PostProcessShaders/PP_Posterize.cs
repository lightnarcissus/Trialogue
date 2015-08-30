using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Posterize")]
public class PP_Posterize : PostProcessBase {
	//Amount of colors
	public float colors = 4.0f;
	//Gamma adjustment
	public float gamma = 1.0f;

	void Awake () {
		base.material.SetFloat ("_Colors", colors);
		base.material.SetFloat ("_Gamma", gamma);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Posterize");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Colors", colors);
		base.material.SetFloat ("_Gamma", gamma);
		Graphics.Blit (source, destination, material);
	}
}