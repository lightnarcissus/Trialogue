using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/HDR")]
public class PP_HDR : PostProcessBase {
	//0.5 is middlepoint (no effect with 1 multiplier)
	//higher the amount, dark the HDR
	//lower the amount, light the HDR
	public float amount = 0.045f;
	//This multiplier should be used as different situations like inside a building or outside..etc
	public float multiplier = 1f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/HDR");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Amount", amount);
		base.material.SetFloat("_Multiplier", multiplier);
		Graphics.Blit (source, destination, material);
	}
}
