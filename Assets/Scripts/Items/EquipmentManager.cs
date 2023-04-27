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
    public SkinnedMeshRenderer TargetMesh;
    public Equipment[] DefaultItems;

    private Equipment[] _currentEquipment;
    private Inventory _inventory;
    private SkinnedMeshRenderer[] _currentMeshes;

    private void Start()
    {
        _inventory = Inventory.Instance;
        int _numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _currentEquipment = new Equipment[_numOfSlots];
        _currentMeshes = new SkinnedMeshRenderer[_numOfSlots];
        EquipDefaultItems();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.EquipSlot;
        Equipment oldItem = Unequip(slotIndex);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        SetEquipmentBlendShapes(newItem, 100);

        _currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.Mesh);
        newMesh.transform.parent = TargetMesh.transform;

        newMesh.bones = TargetMesh.bones;
        newMesh.rootBone = TargetMesh.rootBone;
        _currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if (_currentEquipment[slotIndex] != null)
        {
            if(_currentMeshes[slotIndex] != null)
            {
                Destroy(_currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = _currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            _inventory.Add(oldItem);

            _currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < _currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }
    private void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.CoveredMeshRegions)
        {
            TargetMesh.SetBlendShapeWeight((int)blendShape, weight);    
        }
    }

    private void EquipDefaultItems()
    {
        foreach(Equipment item in DefaultItems)
        {
            Equip(item);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        { 
            UnequipAll();
        }
    }
}
