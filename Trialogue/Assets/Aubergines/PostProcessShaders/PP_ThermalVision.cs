using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/ThermalVision")]
public class PP_ThermalVision : PostProcessBase {
	/*How to use;
	Consider your normal scene as grey scale, this shader turns the light colors
	into reddish and dark colors into bluish which gives you a Predator(The movie) like
	thermal vision effect
	An easy and dirty solution is putting a light, close to Entities which you want to be seen 
	in your thermal vision or make suitable textures for them
	*/
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/ThermalVision");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination, material);
	}
}