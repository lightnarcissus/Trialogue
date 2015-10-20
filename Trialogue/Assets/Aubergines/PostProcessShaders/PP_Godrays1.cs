using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Godrays1")]
public class PP_Godrays1 : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Godrays1");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}