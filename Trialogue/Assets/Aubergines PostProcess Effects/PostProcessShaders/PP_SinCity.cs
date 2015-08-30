using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/SinCity")]
public class PP_SinCity : PostProcessBase {
	/*How to use
	This shader will make your screen greyscale except red values
	So, if you want any object to look reddish;
	use a red color texture on it
	Or
	use a tinting color and adjust this color to pure red or so
	*/
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/SinCity");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}