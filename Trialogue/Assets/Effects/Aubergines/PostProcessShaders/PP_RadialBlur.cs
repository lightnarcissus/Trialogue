using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/RadialBlur")]
public class PP_RadialBlur : PostProcessBase {
	public float centerX = 0.5f; 	//This value is between 0 to 1 (0 is left, 1 is right)
	public float centerY = 0.5f; 	//This value is between 0 to 1 

	void Awake () {
		base.material.SetFloat ("_CenterX", centerX);
		base.material.SetFloat ("_CenterY", centerY);
	}

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/RadialBlur");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_CenterX", centerX);
		base.material.SetFloat ("_CenterY", centerY);
		Graphics.Blit (source, destination, material);
	}
}