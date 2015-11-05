using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LineArt")]
public class PP_LineArt : PostProcessBase {
	public Color lineColor = Color.black;
	public float lineAmount = 80;

	void Awake () {
		base.material.SetVector ("_LineColor", lineColor);
		base.material.SetFloat ("_LineAmount", lineAmount);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/LineArt");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector ("_LineColor", lineColor);
		base.material.SetFloat ("_LineAmount", lineAmount);
		Graphics.Blit (source, destination, material);
	}
}