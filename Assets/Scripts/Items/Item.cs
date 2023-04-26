using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item ")]
public class Item : ScriptableObject
{
    public new string Name = "new item";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;

    public virtual void Use()
    {
        
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
