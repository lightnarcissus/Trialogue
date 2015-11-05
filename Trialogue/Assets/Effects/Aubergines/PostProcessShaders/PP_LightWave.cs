using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LightWave")]
public class PP_LightWave : PostProcessBase {
	//just play with them
	public float red = 4f;
	public float green = 4f;
	public float blue = 4f;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/LightWave");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Red", red);
		base.material.SetFloat("_Green", green);
		base.material.SetFloat("_Blue", blue);
		Graphics.Blit (source, destination, material);
	}
}