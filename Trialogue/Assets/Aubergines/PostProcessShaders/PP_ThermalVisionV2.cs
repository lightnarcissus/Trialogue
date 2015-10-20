using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ThermalVisionV2")]
public class PP_ThermalVisionV2 : PostProcessBase {

	//Use the provided thermal texture for this one for best results or surely you can build up your own
	public Texture thermalTex;
	//Use the provided Noise_1024 texture for this one for best results
	public Texture noiseTex;
	//This value represents the noise multiplier
	public float noiseAmount = 0.3f;

	void Awake () {
		if (thermalTex)
			base.material.SetTexture("_ThermalTex", thermalTex);
		if (noiseTex)
			base.material.SetTexture("_NoiseTex", noiseTex);
		base.material.SetFloat ("_NoiseAmount", noiseAmount);
	}
	void OnEnable () {
		if (!noiseTex || !thermalTex)
			Debug.LogWarning("You must set the necessary textures");
		base.shader = Shader.Find("Hidden/Aubergine/ThermalVisionV2");
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture("_ThermalTex", thermalTex);
		base.material.SetTexture("_NoiseTex", noiseTex);
		base.material.SetFloat ("_NoiseAmount", noiseAmount);
		Matrix4x4 mat = (GetComponent<Camera>().projectionMatrix * GetComponent<Camera>().worldToCameraMatrix).inverse;
		//Matrix4x4 mat = (camera.cameraToWorldMatrix * camera.projectionMatrix).inverse;
		base.material.SetMatrix("_ViewProjectInverse", mat);
		Graphics.Blit (source, destination, base.material);
	}
}