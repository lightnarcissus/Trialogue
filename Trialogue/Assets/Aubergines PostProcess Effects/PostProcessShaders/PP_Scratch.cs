using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Scratch")]
public class PP_Scratch : PostProcessBase {
	public Texture noiseTexture;
	public float speed1 = 0.03f;
	public float speed2 = 0.01f;
	//This value is optimal for the provided Noise_1 texture
	public float intensity = 0.5f;
	public float scratchWidth = 0.01f;

	void Awake () {
		if (noiseTexture)
			base.material.SetTexture ("_Noise", noiseTexture);
		base.material.SetTexture ("_Noise", noiseTexture);
		base.material.SetFloat("_Speed1", speed1);
		base.material.SetFloat("_Speed2", speed2);
		base.material.SetFloat("_Intensity", intensity);
		base.material.SetFloat("_ScratchWidth", scratchWidth);
	}
	void OnEnable () {
		if (!noiseTexture)
			Debug.LogWarning("You must set the noiseTexture Texture");
		base.shader = Shader.Find("Hidden/Aubergine/Scratch");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture ("_Noise", noiseTexture);
		base.material.SetFloat("_Speed1", speed1);
		base.material.SetFloat("_Speed2", speed2);
		base.material.SetFloat("_Intensity", intensity);
		base.material.SetFloat("_ScratchWidth", scratchWidth);
		Graphics.Blit (source, destination, material);
	}
}