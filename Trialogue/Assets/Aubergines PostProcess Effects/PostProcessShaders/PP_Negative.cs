using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Negative")]
public class PP_Negative : PostProcessBase {
	
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Negative");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}