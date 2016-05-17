using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/Charcoal")]
public class PP_Charcoal : PostProcessBase {
	public Color lineColor = Color.red;
	public bool switchSource=false;
	//public Color matColor=Color.red;
	void OnEnable () {
		base.shader = Shader.Find("Hidden/Aubergine/Charcoal");
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		base.material.SetVector("_LineColor", lineColor);
	//	material.color = Color.black;
		material.color=new Color(0f,0f,0f,0f);
		if(!switchSource)
		Graphics.Blit (source,destination, material);
		else
		Graphics.Blit (destination,source, material);
	}
}