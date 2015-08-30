using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Spherical")]
public class PP_Spherical : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Spherical");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}