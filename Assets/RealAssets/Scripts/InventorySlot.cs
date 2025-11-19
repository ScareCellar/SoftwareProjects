using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RealAssets.InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        public Image icon;
        private Item currentItem;

        public Item CurrentItem { get { return currentItem; } private set { currentItem = value; } }

        private void Start()
        {
            CurrentItem = null;
        }

        public void AddItem(Item newItem)
        {
            // For picking up items
            CurrentItem = newItem;
            icon.sprite = newItem.sprite;
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