using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCounter : MonoBehaviour
{
	private DuckContainer duckInContainer;
	public int[] counters;

	private void Awake()
	{
		duckInContainer = GameObject.Find("DuckContainer").GetComponent<DuckContainer>();
	}

	private void Start()
	{
		counters = new int[duckInContainer.duckPrefabList.Length];

		for (int i = 0; i < counters.Length; i++)
		{
			counters[i] = 0;
		}
	}

	public void CountDucksInPool(int kindOfDuck)
	{
		counters[kindOfDuck]++;
	}

	private void CountCollectedDucks(int kindOfDuck)
	{
		counters[kindOfDuck]--;
	}
}
