using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private List<ItemData> items = new List<ItemData>();
    public List<ItemData> Items => items;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AddItem(ItemData newItem)
    {
        items.Add(newItem);
        UI_Inventory.Instance.Refresh(items);
    }

    public bool HasItem(ItemData item) => items.Contains(item);

    public void RemoveItem(ItemData item)
    {
        if (items.Remove(item))
            UI_Inventory.Instance.Refresh(items);
    }
}
