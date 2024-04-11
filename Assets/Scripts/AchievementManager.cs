using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    private void Awake()
    {
        instance = this;
    }

    public Achievement[] achievements;
    public SpecialAchievement[] specials;

    [SerializeField] private int[] duckCounts;
    public int[] kindsofDucks;

    private AchievementPanel panel;
    public AchievePage achievePage;

    void Start()
    {
        duckCounts = new int[achievements.Length];
        panel = GameObject.Find("AchievementPanel").GetComponent<AchievementPanel>();
        InitializeAchievements();
    }

    private void Update()
    {
        if (specials[2].isUnlocked || specials[0].isUnlocked)
        {
            return;
        }
        else
        {
            CheckNonOwnedAchievement();
        }
    }

    void InitializeAchievements()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].Initialize();
        }
    }

    public void UpdateCollectedObjects(int duckId)
    {
        duckCounts[duckId]++;
        kindsofDucks[duckId]++;
        CheckAchievements();
        CheckMyFirstDuckAchievement();
        CheckRainbowAchievement();

    }

    void CheckAchievements()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            if (!achievements[i].isUnlocked && duckCounts[i] >= achievements[i].targetCount)
            {
                achievements[i].Unlock();
                achievePage.CreateContent(achievements[i].name, achievements[i].description);
                DisplayAchievementPopUp(achievements[i]);
            }
        }
    }

    void CheckMyFirstDuckAchievement()
    {
        if (!specials[0].isUnlocked)
        {
            foreach (int count in kindsofDucks)
            {
                if (count > 0)
                {
                    specials[0].satisfied = true;
                }
            }

            if (specials[0].satisfied)
            {
                specials[0].Unlock();
                achievePage.CreateContent(specials[0].name, specials[0].description);
                DisplaySpecialAchievementPopUp(specials[0]);
            }
        }
    }

    void CheckRainbowAchievement()
    {
        if (!specials[1].isUnlocked)
        {
            foreach (int count in kindsofDucks)
            {
                if (count < 1)
                {
                    specials[1].satisfied = false;
                    return;
                }
                else
                {
                    specials[1].satisfied = true;
                }
            }

            if (specials[1].satisfied)
            {
                specials[1].Unlock();
                achievePage.CreateContent(specials[1].name, specials[1].description);
                DisplaySpecialAchievementPopUp(specials[1]);
            }
        }
    }

    void CheckNonOwnedAchievement()
    {
        if (Time.time > 5)
        {
            foreach (int count in kindsofDucks)
            {
                if (count > 0)
                {
                    specials[2].satisfied = false;
                    return;
                }
                else
                {
                    specials[2].satisfied = true;
                }
            }

            if (specials[2].satisfied)
            {
                specials[2].Unlock();
                achievePage.CreateContent(specials[2].name, specials[2].description);
                DisplaySpecialAchievementPopUp(specials[2]);
            }
        }
    }

    private void DisplayAchievementPopUp(Achievement achievement)
    {
        //Debug.Log("Achievement Unlocked: " + achievement.name);
        // Implement pop-up UI display logic here
        panel.PopupAchievement(achievement.name);
    }

    private void DisplaySpecialAchievementPopUp(SpecialAchievement achievement)
    {
        //Debug.Log("Achievement Unlocked: " + achievement.name);
        // Implement pop-up UI display logic here
        panel.PopupAchievement(achievement.name);
    }
}

[System.Serializable]
public class Achievement
{
    public string name;
    public string description;
    public int targetCount;
    public bool isUnlocked;

    public void Initialize()
    {

        isUnlocked = false;
    }

    public void Unlock()
    {
        isUnlocked = true;
    }
}

[System.Serializable]
public class SpecialAchievement
{
    public string name;
    public string description;
    public bool satisfied;
    public bool isUnlocked;

    public void Initialize()
    {
        isUnlocked = false;
    }

    public void Unlock()
    {
        isUnlocked = true;
    }
}

