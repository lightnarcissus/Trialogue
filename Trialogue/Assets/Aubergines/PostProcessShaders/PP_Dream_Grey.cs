using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Dream_Grey")]
public class PP_Dream_Grey : PostProcessBase {
	
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Dream_Grey");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}