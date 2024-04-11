using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPage : MonoBehaviour
{
    [SerializeField] private bool[] collectedChecker = new bool[18];
    [SerializeField] private GameObject[] collectedDuckUIPrefabs = new GameObject[18];
    [SerializeField] private Transform[] duckUIPosition = new Transform[18];
    private Vector3 targetPos = new Vector3(-4.5f, -102f, -100f);

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            duckUIPosition[i] = transform.GetChild(i).GetComponent<Transform>();
        }
    }

    public void CreateCollectedDuck(int duckId)
    {
        if (false == collectedChecker[duckId])
        {
            collectedChecker[duckId] = true;
            duckUIPosition[duckId].GetComponent<Image>().enabled = false;
            duckUIPosition[duckId].GetComponentInChildren<TextMeshProUGUI>().enabled = false;

            GameObject duckUI = Instantiate(collectedDuckUIPrefabs[duckId], duckUIPosition[duckId]);
            duckUI.transform.localPosition = targetPos;
        }
    }




}
