using UnityEngine;
using System.Collections;

public class IKPointer : MonoBehaviour {

	public Transform ikTarget;
	private Animator animator;
	public AvatarIKGoal ikType;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnAnimatorIK()
	{
//		animator.SetIKPosition( ikType, ikTarget.position );
//		animator.SetIKPositionWeight( ikType, 1f );
//		animator.SetIKRotation( ikType, ikTarget.rotation );
//		animator.SetIKRotationWeight( ikType, 1f );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
