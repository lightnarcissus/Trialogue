using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Noise")]
public class PP_Noise : PostProcessBase {
	//Scale of the noise, its best between 0.1 and 1.0
	public float noiseScale = 0.5f;
	//If you want to animate speed and amplitude, you should move below
	//function calls to OnRenderImage
	void Awake () {
		base.material.SetFloat("_NoiseScale", noiseScale);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Noise");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_NoiseScale", noiseScale);
		Graphics.Blit (source, destination, base.material);
	}
}