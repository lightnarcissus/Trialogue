using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlurH")]
public class PP_BlurH : PostProcessBase {
	//This value represents the blur multiplier
	public float blurMultiplier = 1f;

	void Awake () {
		base.material.SetFloat("_BlurMulti", blurMultiplier);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/BlurH");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_BlurMulti", blurMultiplier);
		Graphics.Blit (source, destination, base.material);
	}
}