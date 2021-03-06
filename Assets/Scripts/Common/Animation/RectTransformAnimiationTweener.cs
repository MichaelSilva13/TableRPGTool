﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformAnimiationTweener : Vector3Tweener
{
	private RectTransform rt;

	private void Awake()
	{
		base.Awake();
		rt = transform as RectTransform;
	}

	protected override void OnUpdate(object sender, EventArgs e)
	{
		base.OnUpdate(sender, e);
		rt.anchoredPosition = currentValue;
	}
}
