using UnityEngine;
using UnityEngine.UI;
using TMPro;

using RealAssets.CurrencySystem;

namespace RealAssets.UpgradeSystem
{
    public enum UpgradeScaling
    {
        Linear,
        Exponential,
        PercentageBased
    }

    public class Upgrade : MonoBehaviour
    {
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private int baseUpgradeCost = 100;
        [SerializeField] UpgradeScaling upgradeScaling = UpgradeScaling.Linear;
        [SerializeField] private float scalingFactor = 1.5f;
        private string upgradeName;
        private int currentUpgradeLevel = 0;
        private int curCost;

        private void Awake()
        {
            curCost = baseUpgradeCost;
            upgradeName = upgradeCostText.text;
            upgradeButton.onClick.AddListener(AttemptUpgrade);
            UpdateUpgradeUI();
        }

        private void AttemptUpgrade()
        {
            if (!upgradeButton) return;
            else if (!upgradeButton.interactable) return;
            
            int upgradeCost = CalculateUpgradeCost();
            Debug.Log($"Attempting to upgrade! Cost: {upgradeCost}");
            // TODO: Implement currency check and upgrade logic
            if (Currency.Singleton.SpendMoney(upgradeCost))
            {
                currentUpgradeLevel++;
                curCost = upgradeCost;
                ApplyUpgradeEffects();
                UpdateUpgradeUI();
            }
            else
            {
                Debug.Log("Not enough currency to upgrade!");
            }
        }

        private int CalculateUpgradeCost()
        {
            switch (upgradeScaling)
            {
                case UpgradeScaling.Linear:
                    return (int)(curCost + scalingFactor);
                case UpgradeScaling.Exponential:
                    return (int)(curCost * scalingFactor);
                case UpgradeScaling.PercentageBased:
                    return (int)(curCost * (1 + scalingFactor / 100f));
                default:
                    return curCost;
            }
        }

        private void ApplyUpgradeEffects()
        {
            // TODO: Implement the actual upgrade effects here
            Debug.Log($"Upgraded to level {currentUpgradeLevel}!");
        }

        private void UpdateUpgradeUI()
        {
            upgradeCostText.text = $"{upgradeName}\nCost: {curCost}\nLevel: {currentUpgradeLevel}";
        }
    }
}