using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/TilesXY")]
public class PP_TilesXY : PostProcessBase {
	
	public float numTilesX = 32f;
	public float numTilesY = 32f;
	public float threshold = 0.16f;
	//Color value should be middle colors rather than straight colors
	//in order to see 3d effect
	public Color edgeColor = Color.grey;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/TilesXY");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("numTilesX", numTilesX);
		base.material.SetFloat("numTilesY", numTilesY);
		base.material.SetFloat("threshold", threshold);
		base.material.SetColor("edgeColor", edgeColor);
		Graphics.Blit (source, destination, material);
	}
}