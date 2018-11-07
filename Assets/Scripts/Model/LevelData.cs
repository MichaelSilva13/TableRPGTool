using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : ScriptableObject
{

	private List<Vector3> tiles;
	public List<Vector3> Tiles
	{
		get { return tiles; }
		set { tiles = value; }
	}

}
