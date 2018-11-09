using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionsExtensions{


	public static Directions GetDirections(this Tile t1, Tile t2)
	{
		if (t1.pos.y < t2.pos.y)
		{
			return Directions.NORTH;
		}
		if (t1.pos.x < t2.pos.x)
		{
			return Directions.EAST;
		}
		if (t1.pos.y > t2.pos.y)
		{
			return Directions.SOUTH;
		}
		
		return Directions.WEST;
		
	}

	public static Vector3 toEuler(this Directions d)
	{
		return new Vector3(0, (int)d * 90, 0);
	}
	
}
