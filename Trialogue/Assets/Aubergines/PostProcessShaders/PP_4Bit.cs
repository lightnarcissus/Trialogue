using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/4Bit")]
public class PP_4Bit : PostProcessBase {
	public int bitDepth = 1;
	public float contrast = 1f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/4Bit");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_BitDepth", bitDepth);
		base.material.SetFloat("_Contrast", contrast);
		Graphics.Blit (source, destination, material);
	}
}