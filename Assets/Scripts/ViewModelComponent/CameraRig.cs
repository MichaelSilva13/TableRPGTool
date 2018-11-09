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

	public void rotate(int dir)
	{
		StartCoroutine(turnCamera(dir));
	}
	

	IEnumerator turnCamera(int direction)
	{
		Vector3 rot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		rot.y += direction * 90;
		float duration = (rot.y - transform.eulerAngles.y) * 0.5f;
		Tweener tweener = transform.RotateToLocal(rot, 1f, EasingEquations.EaseInOutQuad);
		while (tweener != null)
			yield return null;
	}
}
