using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Ripple")]
public class PP_Ripple : PostProcessBase {
	public float speed = 4.0f;	//Speed of ripples
	public float amount = 16.0f; //amount of ripples
	public float strength = 0.009f; //strength of ripple
	public float offsetX = 0.0f; 	//This value is between -1 to 1 (-1 is left, 0 is center, 1 is right)
	public float offsetY = 0.0f; 	//This value is between -1 to 1 

	void Awake () {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amount", amount);
		base.material.SetFloat ("_Strength", strength);
		base.material.SetFloat ("_OffsetX", offsetX);
		base.material.SetFloat ("_OffsetY", offsetY);
	}

	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Ripple");
	}
	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetFloat ("_Speed", speed);
		base.material.SetFloat ("_Amount", amount);
		base.material.SetFloat ("_Strength", strength);
		base.material.SetFloat ("_OffsetX", offsetX);
		base.material.SetFloat ("_OffsetY", offsetY);
		Graphics.Blit (source, destination, material);
	}
}