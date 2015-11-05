using UnityEngine;
using System.Collections;

public class RotateIt : MonoBehaviour {
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * 10f);
	}
}