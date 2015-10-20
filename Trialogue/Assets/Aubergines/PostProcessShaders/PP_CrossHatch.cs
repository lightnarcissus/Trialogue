using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/CrossHatch")]
public class PP_CrossHatch : PostProcessBase {
	public Color lineColor = Color.red;
	public float lineWidth = 0.005f;

	void Awake () {
		base.material.SetVector ("_LineColor", lineColor);
		base.material.SetFloat ("_LineWidth", lineWidth);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/CrossHatch");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector ("_LineColor", lineColor);
		base.material.SetFloat ("_LineWidth", lineWidth);
		Graphics.Blit (source, destination, material);
	}
}