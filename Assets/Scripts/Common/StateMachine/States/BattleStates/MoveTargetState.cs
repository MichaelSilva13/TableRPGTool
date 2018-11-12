using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveTargetState : BattleState
{
	List<Tile> tiles;
  
	public override void Enter ()
	{
		base.Enter ();
		Movement mover = owner.currentUnit.GetComponent<Movement>();
		tiles = mover.GetTilesRange(board);
		board.SelectTiles(tiles);
	}
  
	public override void Exit ()
	{
		base.Exit ();
		board.DeSelectTiles(tiles);
		tiles = null;
	}

	protected override void OnMouseMove(object sender, InfoEventArgs<Vector3> e)
	{

		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ScreenPointToRay(e.Info);
		if (Physics.Raycast(ray, out hit))
		{
			Tile t = hit.collider.gameObject.GetComponent<Tile>();
			if (t != null)
			{
				SelectTile(t.pos);
			}
		}
	}

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
  
	protected override void OnFire (object sender, InfoEventArgs<int> e)
	{
		if (tiles.Contains(owner.currentTile))
			owner.ChangeState<MoveSequenceState>();
	}
}