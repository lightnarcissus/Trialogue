using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SobelEdge")]
public class PP_SobelEdge : PostProcessBase {
	
	public float threshold = 0.7f;
	
	void Awake () {
		base.material.SetFloat ("_Threshold", threshold);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/SobelEdge");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Threshold", threshold);
		Graphics.Blit (source, destination, material);
	}
}