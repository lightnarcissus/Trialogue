using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Charcoal")]
public class PP_Charcoal : PostProcessBase {
	public Color lineColor = Color.red;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Charcoal");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector("_LineColor", lineColor);
		material.color = Color.black;
		Graphics.Blit (source, destination, material);
	}
}