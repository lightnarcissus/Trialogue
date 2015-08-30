using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LensCircle")]
public class PP_LensCircle : PostProcessBase {
	//Values should be between 0f and 1f
	//just play with them
	public float radiusX = 1f;
	public float radiusY = 0f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/LensCircle");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_RadiusX", radiusX);
		base.material.SetFloat("_RadiusY", radiusY);
		Graphics.Blit (source, destination, material);
	}
}