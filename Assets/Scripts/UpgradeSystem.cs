using UnityEngine;
using UnityEngine.UI;

namespace RealAssets.UpgradeSystem
{
    public class UpgradeSystem : MonoBehaviour
    {
        public static UpgradeSystem Singleton;
        [SerializeField] private Upgrade[] upgradeButtons;

        private void Awake()
        {
            Singleton = this;
            upgradeButtons = GetComponentsInChildren<Upgrade>();
        }
    }
}