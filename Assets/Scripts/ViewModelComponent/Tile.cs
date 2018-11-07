using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	public const float STEP_HEIGHT = 0.25f;

	private Point pos;
	public Point Pos
	{
		get { return pos; }
		set { pos = value; }
	}

	private int height;
	public int Height
	{
		get { return height; }
		set { height = value; }
	}

	public Vector3 center
	{
		get
		{
			return new Vector3(pos.x, height*STEP_HEIGHT, pos.y);
		}
	}

	void Match()
	{
		transform.localPosition = new Vector3(pos.x, height*STEP_HEIGHT/2f, pos.y);
		transform.localScale = new Vector3(1, height*STEP_HEIGHT, 1);
	}

	void Grow()
	{
		height++;
		Match();
	}

	void Shrink()
	{
		height--;
		Match();
	}

	void Load(Point p, int h)
	{
		pos = p;
		height = h;
		Match();
	}

	void Load(Vector3 v)
	{
		Load(new Point((int)v.x, (int)v.z), (int) v.y);
	}
	
}
