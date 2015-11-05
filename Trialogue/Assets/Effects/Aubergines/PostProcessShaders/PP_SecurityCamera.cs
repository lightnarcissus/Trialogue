using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SecurityCamera")]
public class PP_SecurityCamera : PostProcessBase {
	//just play with them
	public float speed = 2f;
	public float thickness = 3f;
	public float luminance = 0.5f;
	public float darkness = 0.75f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/SecurityCamera");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Speed", speed);
		base.material.SetFloat("_Thickness", thickness);
		base.material.SetFloat("_Luminance", luminance);
		base.material.SetFloat("_Darkness", darkness);
		Graphics.Blit (source, destination, material);
	}
}