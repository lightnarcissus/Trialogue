using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Bleach")]
public class PP_Bleach : PostProcessBase {
	/*How to use;
	This effect darkens the already dark parts without touching the light parts
	*/
	//opacity value should be between 0.0 and 1.0
	//0.0 no effect, 1.0 full effect
	public float opacity = 0.1f;
	
	void Awake () {
		base.material.SetFloat("_Opacity", opacity);
	}
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Bleach");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat("_Opacity", opacity);
		Graphics.Blit (source, destination, base.material);
	}
}