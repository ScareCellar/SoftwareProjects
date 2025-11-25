using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        internal void AttemptUpgrade()
        {
            int upgradeCost = CalculateUpgradeCost();
            Debug.Log($"Attempting to upgrade! Cost: {upgradeCost}");
            // TODO: Implement currency check and upgrade logic
            // if (CurrencySystem.Singleton.CurrentCurrency >= upgradeCost)
            // {
            //     CurrencySystem.Singleton.DeductCurrency(upgradeCost);
            //     currentUpgradeLevel++;
            //     ApplyUpgradeEffects();
            //     UpdateUpgradeUI();
            // }
            // else
            // {
            //     Debug.Log("Not enough currency to upgrade!");
            // }
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