using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Duck : FloatableObject, IPointerClickHandler
{
    public int duckId;

	public void OnPointerClick(PointerEventData eventData)
	{
		
	}

	private void OnEnable()
	{
		RotationSpeed = Random.Range(-12f, 12f);
	}
}
