using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/LightShafts")]
public class PP_LightShafts : PostProcessBase {
	//Vars
	public Transform lightSource;
	public float density = 1.0f;
	public float weight = 1.0f;
	public float decay = 1.0f;
	public float exposure = 1.0f;
	private Vector3 lightSPos;

	void Awake () {
		base.material.SetFloat ("_Density", density);
		base.material.SetFloat ("_Weight", weight);
		base.material.SetFloat ("_Decay", decay);
		base.material.SetFloat ("_Exposure", exposure);
		lightSPos = GetComponent<Camera>().WorldToViewportPoint(lightSource.position);
		base.material.SetVector("_LightSPos", lightSPos);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/LightShafts");
	}
	void Update () {
		//lightSPos = camera.WorldToViewportPoint(lightSource.position);
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		lightSPos = GetComponent<Camera>().WorldToViewportPoint(lightSource.position);
		if (lightSPos.x < 0f || lightSPos.x > 1f || lightSPos.y < 0f || lightSPos.y > 1f || lightSPos.z < 0f) {
			base.material.SetVector("_LightSPos", new Vector3(0.5f, 0.5f, 0f));
			base.material.SetFloat ("_Density", density - density + 0.1f);
			base.material.SetFloat ("_Weight", weight);
			base.material.SetFloat ("_Decay", decay);
			base.material.SetFloat ("_Exposure", exposure);
		}
		else {
			base.material.SetVector("_LightSPos", lightSPos);
			base.material.SetFloat ("_Density", density);
			base.material.SetFloat ("_Weight", weight);
			base.material.SetFloat ("_Decay", decay);
			base.material.SetFloat ("_Exposure", exposure);
		}
		Debug.Log(GetComponent<Camera>().WorldToViewportPoint(lightSource.position));
		Graphics.Blit (source, destination, material);
	}
}