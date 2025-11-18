using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    private Item currentItem;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentItem != null)
        {
            // We will switch CurrentlySelected Sprite to this item
            Debug.Log("Clicked on item: " + currentItem.itemName);
        }
    }

    public void AddItem(Item newItem)
    {
        // For picking up items
        currentItem = newItem;
        icon.sprite = currentItem.sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        // Might be useful for selling?
        currentItem = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}