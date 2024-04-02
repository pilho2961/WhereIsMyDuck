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

    void Start()
    {
        duckCounts = new int[achievements.Length];
        InitializeAchievements();
    }

    private void Update()
    {
        if (!specials[1].isUnlocked)
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
        CheckRainbowAchievement();
    }

    void CheckAchievements()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            if (!achievements[i].isUnlocked && duckCounts[i] >= achievements[i].targetCount)
            {
                achievements[i].Unlock();
                DisplayAchievementPopUp(achievements[i]);
            }
        }
    }

    void CheckRainbowAchievement()
    {
        if (!specials[0].isUnlocked)
        {
            foreach (int count in kindsofDucks)
            {
                if (count < 1)
                {
                    specials[0].satisfied = false;
                    return;
                }
                else
                {
                    specials[0].satisfied = true;
                }
            }

            if (specials[0].satisfied)
            {
                specials[0].Unlock();
                DisplaySpecialAchievementPopUp(specials[0]);
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
                DisplaySpecialAchievementPopUp(specials[1]);
            }
        }
    }

    void DisplayAchievementPopUp(Achievement achievement)
    {
        Debug.Log("Achievement Unlocked: " + achievement.name);
        // Implement pop-up UI display logic here
    }

    void DisplaySpecialAchievementPopUp(SpecialAchievement achievement)
    {
        Debug.Log("Achievement Unlocked: " + achievement.name);
        // Implement pop-up UI display logic here
    }
}

[System.Serializable]
public class Achievement
{
    public string name;
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

