using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private Equipment[] _currentEquipment;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = Inventory.Instance;
        int _numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _currentEquipment = new Equipment[_numOfSlots];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public void Equip(Equipment newItem)
    {
        Equipment oldItem = null;
        int slotIndex = (int)newItem.EquipSlot;

        if (_currentEquipment[slotIndex] != null)
        {
            oldItem = _currentEquipment[slotIndex];
            _inventory.Add(oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        _currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (_currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = _currentEquipment[slotIndex];
            _inventory.Add(oldItem);

            _currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < _currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    
}
