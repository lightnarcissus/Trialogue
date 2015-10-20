using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Holywood")]
public class PP_Holywood : PostProcessBase {

	//This value represents the amount of darkness shader will enhance
	//lower the value, darker the screen
	public float lumThreshold = 0.13f;

	void Awake () {
		base.material.SetFloat ("_LumThreshold", lumThreshold);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Holywood");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_LumThreshold", lumThreshold);
		Graphics.Blit (source, destination, base.material);
	}
}