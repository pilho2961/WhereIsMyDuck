using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGenerator : MonoBehaviour
{
	private DuckContainer duckInContainer;
	private DuckCounter duckCounter;
	private bool stopCondition = false;

	private void Awake()
	{
		duckInContainer = GameObject.Find("DuckContainer").GetComponent<DuckContainer>();
		duckCounter = GameObject.Find("DuckCounter").GetComponent<DuckCounter>();
	}

	private void Start()
	{
		int randomNumToGen = Random.Range(3, 10);

		for (int i = 0; i < randomNumToGen; i++)
		{
			int randomKind = Random.Range(0, duckInContainer.duckPrefabList.Length);

			Instantiate(duckInContainer.duckPrefabList[randomKind], 
				transform.position + (Random.insideUnitSphere * 5), Quaternion.identity, transform.parent);

			duckCounter.CountDucksInPool(randomKind);
		}

		StartCoroutine(GenerateCycle());
	}

	IEnumerator GenerateCycle()
	{
		while (!stopCondition)
		{
			int randomNumToGen = Random.Range(1, 3);
			int randomTimeToGen = Random.Range(3, 15);

			for (int i = 0; i < randomNumToGen; i++)
			{
				int randomKind = Random.Range(0, duckInContainer.duckPrefabList.Length);

				Instantiate(duckInContainer.duckPrefabList[randomKind],
					transform.position + (Random.insideUnitSphere * 5), Quaternion.identity, transform.parent);

				duckCounter.CountDucksInPool(randomKind);
			}

			yield return new WaitForSeconds(randomTimeToGen);
		}
	}
}