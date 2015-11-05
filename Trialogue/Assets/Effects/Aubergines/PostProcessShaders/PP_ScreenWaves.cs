using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ScreenWaves")]
public class PP_ScreenWaves : PostProcessBase {
	//Speed and amplitude of waves
	public float speed = 10.0f;
	public float amplitude = 0.09f;

	void Awake () {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amplitude", amplitude);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/ScreenWaves");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amplitude", amplitude);
		Graphics.Blit (source, destination, material);
	}
}