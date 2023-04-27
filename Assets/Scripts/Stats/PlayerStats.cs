using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void OnEquipmentChanged(Equipment newIttem, Equipment oldItem)
    {
        if (newIttem != null)
        { 
            Armor.AddModifier(newIttem.ArmorModifier);
            Damage.AddModifier(newIttem.DamageModifier);
        }

        if(oldItem != null)
        {
            Armor.RemoveModifier(oldItem.ArmorModifier);
            Damage.RemoveModifier(oldItem.DamageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.Instance.KillPlayer();
    }
}
