using UnityEngine;

public class UpgradeLogic : MonoBehaviour
{
    private UpgradeData upgradeData;
    private TextReferencer display;

    public void Init(UpgradeData data)
    {
        upgradeData = data;
        display = GetComponent<TextReferencer>();
        UpdateDisplay();
    }

    public void TryToUpgrade()
    {
        if (ValueController.amount >= upgradeData.cost)
        {
            ValueController.DecreaseValue(upgradeData.cost);

            upgradeData.amount += 1;
            upgradeData.cost = Mathf.RoundToInt(upgradeData.cost * upgradeData.costIncrement);

            upgradeData.effect?.Invoke();
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        display.SetText("Title", upgradeData.title);
        display.SetText("Cost", $"Cost: {upgradeData.cost}");
        display.SetText("Amount", $"Amount: {upgradeData.amount}");
    }
}
