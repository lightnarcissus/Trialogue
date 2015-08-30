using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/NightVision")]
public class PP_NightVision : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/NightVision");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}
