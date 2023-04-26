using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;
    public GameObject InventoryUi;

    private Inventory _inventory;
    private InventorySlot[] _slots;
    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.onItemChangedCallBack += UpdateUI;

        _slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            InventoryUi.SetActive(!InventoryUi.activeSelf);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if(i < _inventory.Items.Count)
            {
                _slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                _slots[i].ClaerSlot();
            }
        }
    }
}
