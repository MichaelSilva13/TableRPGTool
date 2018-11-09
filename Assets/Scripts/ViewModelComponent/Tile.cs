using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	[HideInInspector] public Tile prev;
	[HideInInspector] public int distance;
	
	public const float STEP_HEIGHT = 0.25f; //Height by wich it will be multiplied to set the height

	public Point pos; //Position of the Tile

	public int height; //Height of the Tile

	public GameObject content;
	
	
	//Center of the Tile
	public Vector3 center
	{
		get
		{
			return new Vector3(pos.x, height*STEP_HEIGHT, pos.y);
		}
	}

	//Mathec the Tile's transform variables so it matches it's variables
	public void Match()
	{
		transform.localPosition = new Vector3(pos.x, height*STEP_HEIGHT/2f, pos.y);
		transform.localScale = new Vector3(1, height*STEP_HEIGHT, 1);
	}

	//Increments the height of the Tile
	public void Grow()
	{
		height++;
		Match();
	}
	
	//Decrements the height of the Tile
	public void Shrink()
	{
		height--;
		Match();
	}

	//Sets the variables of the tile
	public void Load(Point p, int h)
	{
		pos = p;
		height = h;
		Match();
	}

	//Overloaded version of Load so it can function with a vector
	public void Load(Vector3 v)
	{
		Load(new Point((int)v.x, (int)v.z), (int) v.y);
	}
	
}
