using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/NightVisionV2")]
public class PP_NightVisionV2 : PostProcessBase {

	//Use the provided Noise_1024 texture for this one for best results
	public Texture noiseTex;
	//This value represents the noise multiplier
	public float noiseAmount = 0.9f;
	//This value represents the amount of darkness shader will enhance
	//lower the value, brighter the screen
	public float lumThreshold = 0.2f;
	//This is a multiplier for the dark parts 
	//higher the value, brighter the dark parts defined above
	public float brightenFactor = 2.0f;
	//This is the color of vision
	public Color visionColor = Color.green;

	void Awake () {
		if (noiseTex)
			base.material.SetTexture("_NoiseTex", noiseTex);
		base.material.SetFloat ("_NoiseAmount", noiseAmount);
		base.material.SetFloat ("_LumThreshold", lumThreshold);
		base.material.SetFloat ("_BrightenFactor", brightenFactor);
		base.material.SetVector ("_VisionColor", visionColor);
	}
	void OnEnable () {
		if (!noiseTex)
			Debug.LogWarning("You must set the noiseTex Texture");
		base.shader = Shader.Find("Hidden/Aubergine/NightVisionV2");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture("_NoiseTex", noiseTex);
		base.material.SetFloat ("_NoiseAmount", noiseAmount);
		base.material.SetFloat ("_LumThreshold", lumThreshold);
		base.material.SetFloat ("_BrightenFactor", brightenFactor);
		base.material.SetVector ("_VisionColor", visionColor);
		Graphics.Blit (source, destination, base.material);
	}
}