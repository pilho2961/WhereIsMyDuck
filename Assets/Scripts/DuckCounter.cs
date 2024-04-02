using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCounter : MonoBehaviour
{
	private DuckContainer duckInContainer;
    public int allDucksInPool;
	public int totalCollectedDucks;

    public int[] counters;
	public int[] collectedDucks;


	private void Awake()
	{
		duckInContainer = GameObject.Find("DuckContainer").GetComponent<DuckContainer>();
	}

	private void Start()
	{
		counters = new int[duckInContainer.duckPrefabList.Length];
		collectedDucks = new int[duckInContainer.duckPrefabList.Length + duckInContainer.specialDuckPrefabList.Length];

		AchievementManager.instance.kindsofDucks = new int[collectedDucks.Length];

		for (int i = 0; i < counters.Length; i++)
		{
			counters[i] = 0;
		}
	}

	public void CountDucksInPool(int kindOfDuck)
	{
		allDucksInPool++;
		counters[kindOfDuck]++;
	}

	public void CountCollectedDucks(int duckId)
	{
		allDucksInPool--;
        counters[duckId]--;

        totalCollectedDucks++;
		collectedDucks[duckId]++;

        AchievementManager.instance.UpdateCollectedObjects(duckId);
    }
}
