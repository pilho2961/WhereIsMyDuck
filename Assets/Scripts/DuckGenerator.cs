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

			GameObject duck = Instantiate(duckInContainer.duckPrefabList[randomKind], 
				transform.position + (Random.insideUnitSphere * 5), Quaternion.identity, transform.parent);

			duck.GetComponent<Duck>().duckId = randomKind;

			duckCounter.CountDucksInPool(randomKind);
		}

		StartCoroutine(GenerateCycle());
		StartCoroutine(GeneratorContorller());
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

                GameObject duck = Instantiate(duckInContainer.duckPrefabList[randomKind],
					transform.position + (Random.insideUnitSphere * 5), Quaternion.identity, transform.parent);

                duck.GetComponent<Duck>().duckId = randomKind;

                duckCounter.CountDucksInPool(randomKind);
			}

			yield return new WaitForSeconds(randomTimeToGen);
		}
	}

	IEnumerator GeneratorContorller()
	{
        while (true)
        {
            if (duckCounter.allDucksInPool > 25)
            {
                stopCondition = true;
            }
			else if (stopCondition == true && duckCounter.allDucksInPool < 25)
			{
				stopCondition = false;
				StartCoroutine(GenerateCycle());
			}

			yield return new WaitForSeconds(5);
        }
	}
}
