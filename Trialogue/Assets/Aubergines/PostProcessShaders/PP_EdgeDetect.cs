using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/EdgeDetect")]
public class PP_EdgeDetect : PostProcessBase {

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/EdgeDetect");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}