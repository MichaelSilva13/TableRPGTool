using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{

	protected BattleController owner;

	protected float EPSILON = 0.05f;
	
	public CameraRig cameraRig
	{
		get { return owner.cameraRig; }
	}
	public Board board
	{
		get { return owner.board; }
	}
	public LevelData levelData { get { return owner.levelData; }}
	public Transform tileSelectionIndicator { get { return owner.tileSelectionIndicator; }}
	public Point pos { get { return owner.pos; } set { owner.pos = value; }}

	private void Awake()
	{
		owner = GetComponent<BattleController>();
	}
	
	protected int round(float f)
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
	
	protected override void AddListeners ()
	{
		InputController.moveEvent += OnMove;
		InputController.fireEvent += OnFire;
		InputController.camreaTurnEvent += OnCameraMove;

	}
  
	protected override void RemoveListeners ()
	{
		InputController.moveEvent -= OnMove;
		InputController.fireEvent -= OnFire;
		InputController.camreaTurnEvent -= OnCameraMove;
	}
	
	protected virtual void OnMove (object sender, InfoEventArgs<Point> e)
	{
    
	}
  
	protected virtual void OnFire (object sender, InfoEventArgs<int> e)
	{
    
	}

	protected virtual void OnCameraMove(object sender, InfoEventArgs<float> e)
	{
		cameraRig.rotate((int)e.Info*-1);
	}
	
	protected virtual void SelectTile (Point p)
	{
		if (pos == p || !board.tiles.ContainsKey(p))
			return;
		pos = p;
		tileSelectionIndicator.localPosition = board.tiles[p].center;
	}
}
