using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Duck : FloatableObject
{
    public int duckId;

	private void OnEnable()
	{
		RotationSpeed = Random.Range(-12f, 12f);
	}
}
