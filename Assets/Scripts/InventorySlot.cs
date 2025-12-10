using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RealAssets.InventorySystem
{
    [RequireComponent(typeof(RectTransform))]
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        public Image icon;
        private PlantObject currentItem;

        public PlantObject CurrentItem { get { return currentItem; } private set { currentItem = value; } }

        private void Start()
        {
            CurrentItem = null;
        }

        public void AddItem(PlantObject newPlant)
        {
            // For picking up items
            CurrentItem = newPlant;
            icon.sprite = newPlant.icon;
            icon.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            // Might be useful for selling?
            CurrentItem = null;
            icon = null;
        }
    }
}