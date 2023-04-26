using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image Icon;
    public Button RemoveButton;

    private Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;
        Icon.sprite = _item.Icon;
        Icon.enabled = true;
        RemoveButton.interactable = true;
    }
    public void ClaerSlot()
    {
        _item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        RemoveButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(_item);
    }
    public void UseItem()
    {
        if (_item != null)
        {
            _item.Use();
        }
    }
}
