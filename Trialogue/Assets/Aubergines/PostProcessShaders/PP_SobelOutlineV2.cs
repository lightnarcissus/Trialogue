using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelOutlineV2")]
public class PP_SobelOutlineV2 : PostProcessBase {

	public float threshold = 0.7f;
	
	void Awake () {
		base.material.SetFloat ("_Threshold", threshold);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/SobelOutlineV2");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Threshold", threshold);
		Graphics.Blit (source, destination, material);
	}
}