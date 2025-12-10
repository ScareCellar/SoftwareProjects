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

    public enum UpgradeType
    {
        MovementSpeed,
        PlantingSpeed,
        HarvestSpeed
    }

    public class Upgrade : MonoBehaviour
    {
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private int baseUpgradeCost = 100;
        [SerializeField] UpgradeScaling upgradeScaling = UpgradeScaling.Linear;
        [SerializeField] private UpgradeType upgradeType = UpgradeType.MovementSpeed;
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
            // TODO: Implement specific upgrade effects based on upgradeType
            switch (upgradeType)
            {
                case UpgradeType.MovementSpeed:
                    Movement movement = FindObjectOfType<Movement>();
                    if (movement != null)
                    {
                        movement.PurchaseMovementUpgrade(0.5f); // Example increment
                    }
                    break;
                case UpgradeType.PlantingSpeed:
                    // Implement planting speed upgrade logic
                    break;
                case UpgradeType.HarvestSpeed:
                    // Implement harvest speed upgrade logic
                    break;
                default:
                    break;
            }
        }

        private void UpdateUpgradeUI()
        {
            upgradeCostText.text = $"{upgradeName}\nCost: {curCost}\nLevel: {currentUpgradeLevel}";
        }
    }
}