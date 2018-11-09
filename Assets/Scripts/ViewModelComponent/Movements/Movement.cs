﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{

	public int range, jumpHeight;

	protected Unit unit;
	protected Transform jumper;

	private void Awake()
	{
		unit = GetComponent<Unit>();
		jumper = transform.Find("Jumper");
	}

	public virtual List<Tile> GetTilesRange(Board board)
	{
		List<Tile> retValue = board.Search( unit.tile, ExpandSearch );
		Filter(retValue);
		return retValue;
	}

	protected virtual bool ExpandSearch(Tile From, Tile to)
	{
		return (From.distance + 1) <= range;
	}

	protected virtual void Filter(List<Tile> tiles)
	{
		for (int i = tiles.Count - 1; i >= 0; i--)
		{
			if (tiles[i].content != null)
				tiles.RemoveAt(i);
		}
	}

	public abstract IEnumerator Traverse(Tile t);
	
	protected virtual IEnumerator Turn (Directions dir)
	{
		TransformLocalEulerTweener t = (TransformLocalEulerTweener)transform.RotateToLocal(dir.toEuler(), 0.25f, EasingEquations.EaseInOutQuad);
  
		// When rotating between North and West, we must make an exception so it looks like the unit
		// rotates the most efficient way (since 0 and 360 are treated the same)
		if (Mathf.Approximately(t.startValue.y, 0f) && Mathf.Approximately(t.endValue.y, 270f))
			t.startValue = new Vector3(t.startValue.x, 360f, t.startValue.z);
		else if (Mathf.Approximately(t.startValue.y, 270) && Mathf.Approximately(t.endValue.y, 0))
			t.endValue = new Vector3(t.startValue.x, 360f, t.startValue.z);
		unit.dir = dir;
  
		while (t != null)
			yield return null;
	}
}
