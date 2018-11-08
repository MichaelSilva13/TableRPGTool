using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{

	public float speed = 3.0f;
	public Transform follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (follow)
		{
			transform.position = Vector3.Lerp(transform.position, follow.position, speed * Time.deltaTime);
		}
	}
}
