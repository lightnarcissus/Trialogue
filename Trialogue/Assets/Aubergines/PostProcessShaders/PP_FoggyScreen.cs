using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/FoggyScreen")]
public class PP_FoggyScreen : PostProcessBase {
	
	//Fog Color
	public Color fogColor = Color.gray;
	//Fog thickness
	public float fogThickness = 1f;

	void Awake () {
		base.material.SetVector ("_FogColor", fogColor);
		base.material.SetFloat ("_FogThickness", fogThickness);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/FoggyScreen");
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector ("_FogColor", fogColor);
		base.material.SetFloat ("_FogThickness", fogThickness);
		Graphics.Blit (source, destination, base.material);
	}
}