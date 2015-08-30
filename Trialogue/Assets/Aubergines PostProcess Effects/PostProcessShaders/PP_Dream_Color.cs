using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Dream_Color")]
public class PP_Dream_Color : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Dream_Color");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}