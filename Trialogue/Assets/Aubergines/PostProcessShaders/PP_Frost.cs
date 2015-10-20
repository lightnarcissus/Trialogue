using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Frost")]
public class PP_Frost : PostProcessBase {
	//This is a 2D noiseMap which you can find a sample in _Textures folder
	public Texture noiseMap;
	//This is the amount of freezing
	//If you use the Noise_1 texture provided, best value is between 0 and 1
	public float frequenzy = 1.0f;
	
	void Awake () {
		if (noiseMap)
			base.material.SetTexture ("_NoiseMap", noiseMap);
	}
	void OnEnable () {
		if (!noiseMap)
			Debug.LogWarning("You must set the noiseMap Texture");
		base.shader = Shader.Find("Hidden/Aubergine/Frost");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture ("_NoiseMap", noiseMap);
		base.material.SetFloat ("_Amount", frequenzy);
		Graphics.Blit (source, destination, material);
	}
}