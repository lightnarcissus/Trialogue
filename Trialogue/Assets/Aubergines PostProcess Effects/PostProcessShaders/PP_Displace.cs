using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Displacement")]
public class PP_Displace : PostProcessBase {
	//This is the texture you want the screen to be displaced with
	public Texture bumpTexture;
	//This is the amount of displacement
	public float bumpAmount = 0.5f;

	void Awake () {
		if (bumpTexture)
			base.material.SetTexture ("_BumpTex", bumpTexture);
		base.material.SetFloat ("_Amount", bumpAmount);
	}
	void OnEnable () {
		if (!bumpTexture)
			Debug.LogWarning("You must set the bumpTexture Texture");
		base.shader = Shader.Find("Hidden/Aubergine/Displacement");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture ("_BumpTex", bumpTexture);
		base.material.SetFloat ("_Amount", bumpAmount);
		Graphics.Blit (source, destination, material);
	}
}