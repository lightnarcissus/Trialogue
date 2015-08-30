using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Thicken")]
public class PP_Thicken : PostProcessBase {
	/*How to use;
	This effect is just like bleach, it darkens the already dark parts
	Additionally strengthens the already light parts
	In the whole screen
	*/
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Thicken");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, base.material);
	}
}