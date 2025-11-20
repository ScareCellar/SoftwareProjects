using UnityEngine;
using UnityEngine.UI;

namespace RealAssets.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Singleton;
        public static InventorySlot CurrentlySelectedSlot;

        [SerializeField] private InventorySlot[] slots; // 6 slots for now

        [Header("Items Database")]
        [SerializeField] private Item[] itemsDatabase; // One right now for testing

        private void Awake()
        {
            Singleton = this;
        }

        private void Update()
        {
            // For testing purposes only
            if (Input.GetKeyDown(KeyCode.I))
            {
                RandomItemToInventory();
            }
            // Switch currently selected item
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentlySelectedSlot = slots[0].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentlySelectedSlot = slots[1].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentlySelectedSlot = slots[2].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CurrentlySelectedSlot = slots[3].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                CurrentlySelectedSlot = slots[4].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                CurrentlySelectedSlot = slots[5].GetComponent<InventorySlot>();
                GameObject.FindObjectOfType<CurrentlySelected>().Move(CurrentlySelectedSlot.icon.rectTransform.position);
            }
        }

        public void RandomItemToInventory()
        {
            // For testing purposes only
            Item randomItem = itemsDatabase[Random.Range(0, itemsDatabase.Length)];
            foreach (InventorySlot slot in slots)
            {
                if (slot.CurrentItem == null)
                {
                    Debug.Log("Adding random item to inventory");
                    slot.AddItem(randomItem);
                    break;
                }
            }
        }

    }
}
