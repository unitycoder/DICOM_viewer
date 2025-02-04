﻿using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationHandler : MonoBehaviour, IInputHandler
{
	private OpenSeriesHandler openSeries;
	public Annotation annotation;

	void Start()
	{
		openSeries = transform.parent.GetComponent<OpenSeriesHandler>();
	}

	public void OnInputDown(InputEventData eventData)
	{
	}

	public void OnInputUp(InputEventData eventData)
	{
		Debug.Log("annotation moved!");
		annotation.SetFromTransform(transform);
		if (openSeries.is3D)
		{
			annotation.frame = null;
		}
		else
		{
			annotation.frame = openSeries.frame;
		}
		openSeries.loadDicomInstance.SaveAnnotations();
	}
}
