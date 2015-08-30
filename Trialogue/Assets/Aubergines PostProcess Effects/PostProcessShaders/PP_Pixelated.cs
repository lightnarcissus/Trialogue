using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pixelated")]
public class PP_Pixelated : PostProcessBase {
	//pixel width and height in screen size
	public float pixWidth = 16.0f;
	public float pixHeight = 16.0f;

	void Awake () {
		base.material.SetFloat ("_PixWidth", pixWidth);
		base.material.SetFloat ("_PixHeight", pixHeight);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Pixelated");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_PixWidth", pixWidth);
		base.material.SetFloat ("_PixHeight", pixHeight);
		Graphics.Blit (source, destination, material);
	}
}