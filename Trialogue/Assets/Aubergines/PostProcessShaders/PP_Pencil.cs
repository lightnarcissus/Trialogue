using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Pencil")]
public class PP_Pencil : PostProcessBase {
	//This is the texture you want the screen to be displaced with
	public Texture pencilTexture;
	//This is the amount of displacement
	public float effectStrength = 0.5f;
	public float brightness = 0.5f;

	void Awake () {
		if (pencilTexture)
			base.material.SetTexture ("_PencilTex", pencilTexture);
		base.material.SetFloat ("_Amount", effectStrength);
		base.material.SetFloat ("_Brightness", brightness);
	}
	void OnEnable () {
		if (!pencilTexture)
			Debug.LogWarning("You must set the pencilTexture Texture");
		base.shader = Shader.Find("Hidden/Aubergine/Pencil");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetTexture ("_PencilTex", pencilTexture);
		base.material.SetFloat ("_Amount", effectStrength);
		base.material.SetFloat ("_Brightness", brightness);
		Graphics.Blit (source, destination, material);
	}
}