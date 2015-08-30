using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlurV")]
public class PP_BlurV : PostProcessBase {
	//This value represents the blur multiplier
	public float blurMultiplier = 1f;

	void Awake () {
		base.material.SetFloat("_BlurMulti", blurMultiplier);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/BlurV");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_BlurMulti", blurMultiplier);
		Graphics.Blit (source, destination, base.material);
	}
}