using UnityEngine;
using System;
using System.Collections.Generic;

public class UpgradeData
{
    public int cost;
    public string title;
    public int amount;
    public float costIncrement;
    public bool panelCreated;
    public Action effect;
}

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Transform upgradeContainer;

    private GameObject prefab;

    void Start()
    {
        prefab = Resources.Load<GameObject>("UpgradePanel");
    }

    private readonly List<UpgradeData> upgrades = new List<UpgradeData>
    {
        new() { cost = 10, title = "+ Clicking Strength", amount = 0, costIncrement = 1.5f, effect = () => ButtonIncrementer.incrementValue += 1f},
        new() { cost = 50, title = "++ Clicking Strength", amount = 0, costIncrement = 1.8f, effect = () => ButtonIncrementer.incrementValue += 3f},
    };

    private void CreateUpgrade(UpgradeData upgrade)
    {
        GameObject upgradePanel = Instantiate(prefab, upgradeContainer);
        UpgradeLogic upgrader = upgradePanel.GetComponent<UpgradeLogic>();
        upgrader.Init(upgrade);
    }

    private void CheckUpgrades(float value)
    {
        foreach (var upgrade in upgrades)
        {
            if (value >= upgrade.cost && !upgrade.panelCreated)
            {
                upgrade.panelCreated = true;
                CreateUpgrade(upgrade);
            }
        }
    }

    private void OnEnable()
    {
        ValueController.OnValueChanged += CheckUpgrades;
    }

    private void OnDisable()
    {
        ValueController.OnValueChanged -= CheckUpgrades;
    }
}
