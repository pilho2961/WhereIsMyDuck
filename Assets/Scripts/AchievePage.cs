using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievePage : MonoBehaviour
{
    public GameObject contentPrefab;

    //private void OnEnable()
    //{
    //    var commonAchieve = AchievementManager.instance.achievements;
    //    var specialAchieve = AchievementManager.instance.specials;

    //    for (int i = 0; i < commonAchieve.Length; i++)
    //    {
            
    //    }

    //    for (int i = 0; i < specialAchieve.Length; i++)
    //    {

    //    }
    //}

    public void CreateContent(string name, string description)
    {
        GameObject content = Instantiate(contentPrefab, transform);

        content.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = $"    {name}   | ";
        content.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description;
    }
}
