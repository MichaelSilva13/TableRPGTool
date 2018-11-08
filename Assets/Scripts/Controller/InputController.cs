using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour {
	
	private Repeater _hor = new Repeater("Horizontal");
	private Repeater _ver = new Repeater("Vertical");

	private string[] btns = {"Fire1", "Fire2", "Fire3"};

	public static EventHandler<InfoEventArgs<Point>> moveEvent;
	public static EventHandler<InfoEventArgs<int>> fireEvent;
	public static EventHandler<InfoEventArgs<float>> camreaTurnEvent;
	
	private const float EPSILON = 0.001f;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		int x = _hor.Update();
		int y = _ver.Update();

		if (Input.GetButtonUp("CameraTurnLeft"))
		{
			if (camreaTurnEvent != null)
			{
				camreaTurnEvent(this, new InfoEventArgs<float>(-1f));
			}
		}
		else if (Input.GetButtonUp("CameraTurnRight"))
		{
			if (camreaTurnEvent != null)
			{
				camreaTurnEvent(this, new InfoEventArgs<float>(1f));
			}
			
		}

		if (x != 0 || y != 0)
		{
			if (moveEvent != null)
			{
				moveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
			}
		}


		for (int i = 0; i < btns.Length; i++)
		{
			if (Input.GetButtonUp(btns[i]))
			{
				if(fireEvent!=null)
					fireEvent(this, new InfoEventArgs<int>(i));
			}
		}
	}

	private class Repeater
	{
		private const float THRESHOLD = 0.5f;
		private const float RATE = 0.1f;

		private float _next;
		private bool _hold;
		private string _axis;

		public Repeater(string axis)
		{
			_axis = axis;
		}

		public int Update()
		{
			int retValue = 0;
			int value = Mathf.RoundToInt(Input.GetAxisRaw(_axis));

			if (value != 0)
			{
				if (Time.time > _next)
				{
					retValue = value;
					_next = Time.time + (_hold ? RATE : THRESHOLD);
					_hold = true;
				}
			}
			else
			{
				_hold = false;
				_next = 0;
			}

			return retValue;
		}

	}
}
