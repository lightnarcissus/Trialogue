using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/FakeSSAO")]
public class PP_FakeSSAO : PostProcessBase {
	//The lower this number is, darker the scene
	public int baseC = 4;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/FakeSSAO");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_BaseC", baseC);
		Graphics.Blit (source, destination, material);
	}
}
