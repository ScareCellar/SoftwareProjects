using UnityEngine;
using UnityEngine.UI;
using TMPro;

using RealAssets.CurrencySystem;

namespace RealAssets.UpgradeSystem
{
    public class Upgrade : MonoBehaviour
    {
        [SerializeField] internal Button upgradeButton;
        [SerializeField] private TMP_Text upgradeCostText;
        [SerializeField] private int baseUpgradeCost = 100;
        private int currentUpgradeLevel = 0;

        private void Awake()
        {
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
            return baseUpgradeCost * (currentUpgradeLevel + 1);
        }

        private void ApplyUpgradeEffects()
        {
            // Implement the actual upgrade effects here
            Debug.Log($"Upgraded to level {currentUpgradeLevel}!");
        }

        internal void UpdateUpgradeUI()
        {
            upgradeCostText.text = $"Upgrade Cost: {CalculateUpgradeCost()}";
        }
    }
}