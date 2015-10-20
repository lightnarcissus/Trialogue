using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Scanlines")]
public class PP_Scanlines : PostProcessBase {
	public float intense1 = 0.9f;
	public float intense2 = 0.5f;
	public float count = 15.0f;

	void Awake () {
		base.material.SetFloat("_Intense1", intense1);
		base.material.SetFloat("_Intense2", intense2);
		base.material.SetFloat("_Count", count);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Scanlines");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Intense1", intense1);
		base.material.SetFloat("_Intense2", intense2);
		base.material.SetFloat("_Count", count);
		Graphics.Blit (source, destination, material);
	}
}