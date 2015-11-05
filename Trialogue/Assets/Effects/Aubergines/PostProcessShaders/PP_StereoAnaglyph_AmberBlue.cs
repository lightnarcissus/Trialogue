using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/StereoAnaglyph_AmberBlue")]
public class PP_StereoAnaglyph_AmberBlue : PostProcessBase {
	//This value is best between 0.001 to 0.01
	public float distance = 0.005f;
	
	//If you want to animate distance
	//Move below function call to OnRenderImage
	void Awake () {
		base.material.SetFloat("_Distance", distance);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/StereoAnaglyph_AmberBlue");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		//Dont mess with the below
		base.material.SetFloat("_Distance", distance);
		base.material.SetFloat("_TexSizeX", source.width);
		base.material.SetFloat("_TexSizeY", source.height);
		Graphics.Blit (source, destination, material);
	}
}