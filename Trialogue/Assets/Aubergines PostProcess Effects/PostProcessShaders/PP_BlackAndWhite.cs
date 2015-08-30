using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BlackAndWhite")]
public class PP_BlackAndWhite : PostProcessBase {

	//This value represents the middle gray color (between 0 and 1)
	public float threshold = 0.5f;

	void Awake () {
		base.material.SetFloat ("_Threshold", threshold);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/BlackAndWhite");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Threshold", threshold);
		Graphics.Blit (source, destination, base.material);
	}
}