using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot EquipSlot;
    public int ArmorModifier;
    public int DamageModifier;
    public SkinnedMeshRenderer Mesh;
    public EquipmentMeshRegion[] CoveredMeshRegions; 

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
public enum EquipmentMeshRegion {Legs, Arms, Torso};
