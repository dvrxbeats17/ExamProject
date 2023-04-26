using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singletone
    public static Inventory Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("More than one instance of Invenotory found!");
        }
        Instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public List<Item> Items = new List<Item>();
    public OnItemChanged onItemChangedCallBack;

    [SerializeField] private int space = 2;
    public bool Add(Item item)
    {
        if(!item.IsDefaultItem)
        {
            if(Items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            Items.Add(item);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
