using UnityEngine;
using System.Collections.Generic;

public class AchievementController : MonoBehaviour
{
    [SerializeField] private Transform achievementContainer;

    private HashSet<int> unlockedAchievements = new HashSet<int>();
    private GameObject prefab;
    
    void Start()
    {
        prefab = Resources.Load<GameObject>("AchievementPanel");
    }

    private struct AchievementData
    {
        public int threshold;
        public string title;
        public string description;
    }

    private readonly List<AchievementData> achievements = new List<AchievementData>
    {
        new() { threshold = 10,     title = "Starting Out",    description = "For having reached a value of 10." },
        new() { threshold = 100,    title = "Evolving",        description = "For having reached a value of 100." },
        new() { threshold = 300,    title = "Carpal Tunnel",   description = "For having reached a value of 300." },
    };

    private void CheckAchievement(float value)
    {
        for (int i = achievements.Count - 1; i >= 0; i--)
        {
            var achievement = achievements[i];

            if (value >= achievement.threshold && !unlockedAchievements.Contains(achievement.threshold))
            {
                unlockedAchievements.Add(achievement.threshold);
                CreateAchievement(achievement.title, achievement.description);
                achievements.RemoveAt(i);
            }
        }
    }

    private void CreateAchievement(string title, string description)
    {
        GameObject achievement = Instantiate(prefab, achievementContainer);
        achievement.name = title;
        TextReferencer display = achievement.GetComponent<TextReferencer>();
        display.SetText("Title", title);
        display.SetText("Description", description);
    }

    private void OnEnable()
    {
        ValueController.OnValueChanged += CheckAchievement;
    }

    private void OnDisable()
    {
        ValueController.OnValueChanged -= CheckAchievement;
    }
}
