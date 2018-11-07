using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour {
	
	[SerializeField] private GameObject tileViewPrefab;
	[SerializeField] private GameObject tileSelectionIndicatorPrefab;
	
	[SerializeField] private int width = 10, depth = 10, height = 8;

	[SerializeField] private Point pos;

	[SerializeField] private LevelData levelData;

	Rect randomRect()
	{
		int x = UnityEngine.Random.Range(0, width);
		int y = UnityEngine.Random.Range(0, depth);
		int w = UnityEngine.Random.Range(1, width - x + 1);
		int h = UnityEngine.Random.Range(1, depth - y + 1);
		
		return new Rect(x, y, w, h);
	}

	void GrowRect(Rect r)
	{
		for (int y = (int) r.yMin; y < (int)r.yMax; y++)
		{
			for (int x = (int) r.xMin; x < (int)r.xMax; y++)
			{
				Point p = new Point(x,y);
				
			}
		}
	}

	private Transform marker;
	public Transform Marker
	{
		get { if (marker == null)
			{
				GameObject instance = Instantiate(tileSelectionIndicatorPrefab) as GameObject;
				marker = instance.transform;
			}
			return marker; }
	}
	
	Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();
	
}
