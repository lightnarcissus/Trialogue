using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Amnesia")]
public class PP_Amnesia : PostProcessBase {
	//Speed and amplitude of Wiggles
	public float density = 1.0f;
	public float speed = 3.0f;

	void Awake () {
		base.material.SetFloat ("_Density", density);
		base.material.SetFloat ("_Speed", speed);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Amnesia");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Density", density);
		base.material.SetFloat ("_Speed", speed);
		Graphics.Blit (source, destination, material);
	}
}