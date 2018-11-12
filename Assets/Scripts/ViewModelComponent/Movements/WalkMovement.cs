using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : Movement {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	protected override bool ExpandSearch (Tile from, Tile to)
	{
		// Skip if the distance in height between the two tiles is more than the unit can jump
		if ((Mathf.Abs(from.height - to.height) > jumpHeight))
			return false;
		// Skip if the tile is occupied by an enemy
		if (to.content != null)
			return false;
		return base.ExpandSearch(from, to);
	}

	public override IEnumerator Traverse(Tile t)
	{
		unit.Place(t);
		
		List<Tile> targets = new List<Tile>();

		while (t!=null)
		{
			targets.Insert(0, t);
			t = t.prev;
		}
		
		// Move to each way point in succession
		for (int i = 1; i < targets.Count; ++i)
		{
			Tile from = targets[i-1];
			Tile to = targets[i];
			Directions dir = from.GetDirections(to);
			if (unit.dir != dir)
				yield return StartCoroutine(Turn(dir));
			if (from.height == to.height)
				yield return StartCoroutine(Walk(to));
			else
				yield return StartCoroutine(Jump(to));
		}
		yield return null;

	}
	
	IEnumerator Walk (Tile target)
	{
		Tweener tweener = transform.MoveTo(target.center, 0.25f, EasingEquations.Linear);
		while (tweener != null)
			yield return null;
	}
	
	IEnumerator Jump (Tile to)
	{
		Debug.Log(to.center);
		Tweener tweener = transform.MoveTo(to.center, 1f, EasingEquations.EaseOutQuad);
		Tweener t2 = jumper.MoveToLocal(new Vector3(0, Tile.STEP_HEIGHT * 10f, 0), tweener.easingControl.duration / 1f, EasingEquations.EaseOutCirc);
		t2.easingControl.loopCount = 1;
		t2.easingControl.loopType = EasingControl.LoopType.PingPong;
		while (tweener != null)
			yield return null;
	}
}
