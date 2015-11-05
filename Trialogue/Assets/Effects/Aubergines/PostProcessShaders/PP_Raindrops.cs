using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Raindrops")]
public class PP_Raindrops : PostProcessBase {
	//This is the texture you want the screen to be displaced with
	public Texture bumpTexture;
	//This is the amount of displacement
	public float bumpAmount = 0.7f;
	public float speedX = 0.0f;
	public float speedY = 0.1f;

	void Awake () {
		if (bumpTexture)
			base.material.SetTexture ("_BumpTex", bumpTexture);
	}
	void OnEnable () {
		if (!bumpTexture)
			Debug.LogWarning("You must set the bumpTexture Texture");
		base.shader = Shader.Find("Hidden/Aubergine/Raindrops");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture ("_BumpTex", bumpTexture);
		base.material.SetFloat ("_Amount", bumpAmount);
		base.material.SetFloat ("_SpeedX", speedX);
		base.material.SetFloat ("_SpeedY", speedY);
		Graphics.Blit (source, destination, material);
	}
}