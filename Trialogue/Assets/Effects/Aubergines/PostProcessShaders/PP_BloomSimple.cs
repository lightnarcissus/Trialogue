using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BloomSimple")]
public class PP_BloomSimple : PostProcessBase {
	//Color
	public float strength = 0.5f;

	void Awake () {
		base.material.SetFloat("_Strength", strength);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/BloomSimple");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Strength", strength);
		Graphics.Blit (source, destination, base.material);
	}
}