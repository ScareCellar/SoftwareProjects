using UnityEngine;
using UnityEngine.UI;
using TMPro;

// VERY BASIC CURRENCY SYSTEM

namespace RealAssets.CurrencySystem
{
    public class Currency : MonoBehaviour
    {
        public static Currency Singleton;

        [SerializeField] private int currentMoney = 0;
        [SerializeField] private TMP_Text moneyText;

        private void Awake()
        {
            Singleton = this;
            UpdateMoneyUI();
        }

        public void AddMoney(int amount)
        {
            currentMoney += amount;
            UpdateMoneyUI();
        }

        public bool SpendMoney(int amount)
        {
            if (currentMoney >= amount)
            {
                currentMoney -= amount;
                UpdateMoneyUI();
                return true;
            }
            return false;
        }

        private void UpdateMoneyUI()
        {
            if (moneyText != null)
            {
                moneyText.text = "Money: " + currentMoney.ToString();
            }
        }
    }
}