using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Tiles")]
public class PP_Tiles : PostProcessBase {
	
	public float numTiles = 32f;
	public float threshold = 0.16f;
	//Color value should be middle colors rather than straight colors
	//in order to see 3d effect
	public Color edgeColor = Color.grey;

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Tiles");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("numTiles", numTiles);
		base.material.SetFloat("threshold", threshold);
		base.material.SetColor("edgeColor", edgeColor);
		Graphics.Blit (source, destination, material);
	}
}