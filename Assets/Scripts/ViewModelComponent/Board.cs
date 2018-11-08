using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private GameObject TilePrefab;
	public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

	public void Load(LevelData data)
	{
		for (int i = 0; i < data.tiles.Count; i++)
		{
			GameObject instance = Instantiate(TilePrefab) as GameObject;
			Tile t = instance.GetComponent<Tile>();
			t.Load(data.tiles[i]);
			tiles.Add(t.pos, t);

		}
	}
	
}
