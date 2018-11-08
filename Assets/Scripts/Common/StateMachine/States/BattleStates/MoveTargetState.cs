using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetState : BattleState
{

	private Vector3 cameraRot;
	private const float EPSILON = 0.1f;

	protected override void OnMove (object sender, InfoEventArgs<Point> e)
	{
		float facing = cameraRig.transform.GetChild(0).transform.eulerAngles.y;
		Vector3 input =  Quaternion.Euler(0f, facing, 0f) * new Vector3(e.Info.x, 0, e.Info.y);
		
		int newX = round(input.x);
		int newY = round(input.z);

		if (e.Info.x == 0 && newY != 0)
		{
			newX = 0;
		}
		if (e.Info.y == 0 && newX != 0)
		{
			newY = 0;
		}
		e.Info = new Point(newX, newY);
		Debug.Log(e.Info + " " + input);
		SelectTile(e.Info + pos);
	}

	private int round(float f)
	{
		if (f >= EPSILON)
		{
			return Mathf.CeilToInt(f);
		}
		if(f <= -EPSILON)
		{
			return Mathf.FloorToInt(f);
		}

		return 0;
	}

	protected override void OnCameraMove(object sender, InfoEventArgs<float> e)
	{
		Debug.Log(e.Info);
		cameraRot = new Vector3(0, e.Info*90, 0);
		cameraRig.transform.GetChild(0).transform.eulerAngles += cameraRot;
	}
	
 
}
