using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Desaturate")]
public class PP_Desaturate : PostProcessBase {
	//This value should be between 0 and 1
	//0 retains original colors, 1 completely desaturates screen
	public float desaturate = 0.5f;

	void Awake () {
		base.material.SetFloat("_Amount", desaturate);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Desaturate");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Amount", desaturate);
		Graphics.Blit (source, destination, material);
	}
}