using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementPanel : MonoBehaviour
{
    public GameObject achieveContentPrefab;

    public void PopupAchievement(string achieveName)
    {
        GameObject content = Instantiate(achieveContentPrefab, transform);
        content.GetComponentInChildren<TextMeshProUGUI>().text = achieveName;
    }
}
