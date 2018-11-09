using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitState : BattleState {

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
	
	protected override void OnCameraMove(object sender, InfoEventArgs<float> e)
	{
		cameraRig.rotate((int)e.Info*-1);
	}
  
	protected override void OnFire (object sender, InfoEventArgs<int> e)
	{
		GameObject content = owner.currentTile.content;
		if (content != null)
		{
			Debug.Log(content);
			owner.currentUnit = content.GetComponent<Unit>();
			owner.ChangeState<MoveTargetState>();
		}
	}
}
