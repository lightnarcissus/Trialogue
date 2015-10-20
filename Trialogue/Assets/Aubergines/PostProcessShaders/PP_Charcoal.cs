using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Charcoal")]
public class PP_Charcoal : PostProcessBase {
	public Color lineColor = Color.black;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Charcoal");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector("_LineColor", lineColor);
		Graphics.Blit (source, destination, material);
	}
}