using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace RealAssets.InventorySystem
{
    [RequireComponent(typeof(RectTransform))]
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        public Image icon;
        [SerializeField]
        public PlantObject.PlantType holdingType = PlantObject.PlantType.Seed;
        [SerializeField]
        public TMP_Text itemCountText;
        private PlantObject currentItem;
        public PlantObject CurrentItem { get { return currentItem; } private set { currentItem = value; } }
        private int numItems = 0;
        public int NumItems { get { return numItems; } private set { numItems = value; } }

        private void Start()
        {
            CurrentItem = null;
        }

        public void AddItem(PlantObject newPlant)
        {
            if (newPlant.plantType != holdingType)
            {
                Debug.LogWarning("Trying to add wrong type of item to slot!");
                return;
            }
            if (CurrentItem != null && CurrentItem == newPlant)
            {
                // Stack item
                numItems++;
                itemCountText.text = numItems.ToString();
                return;
            }
            // For picking up new items
            numItems = 1;
            itemCountText.text = numItems.ToString();
            CurrentItem = newPlant;
            icon.sprite = newPlant.icon;
            icon.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;
            icon.enabled = true;
        }

        public void RemoveItem()
        {
            if (CurrentItem == null)
            {
                Debug.LogWarning("No item to remove from slot!");
                return;
            }
            numItems--;
            if (numItems <= 0 && holdingType != PlantObject.PlantType.Seed)
            {
                ClearSlot();
                return;
            }
            itemCountText.text = numItems.ToString();
        }

        public void ClearSlot()
        {
            if (holdingType == PlantObject.PlantType.Seed)
            {
                Debug.LogWarning("Cannot clear seed slots!");
                return;
            }
            // Might be useful for selling?
            CurrentItem = null;
            icon.sprite = null;
            icon.enabled = false;
            numItems = 0;
        }
    }
}