using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Emboss")]
public class PP_Emboss : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Emboss");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}
