using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV7")]
public class PP_SobelOutlineV7 : PostProcessBase {

	public float threshold = 0.7f;
	
	void Awake () {
		base.material.SetFloat ("_Threshold", threshold);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV7");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Threshold", threshold);
		Graphics.Blit (source, destination, material);
	}
}