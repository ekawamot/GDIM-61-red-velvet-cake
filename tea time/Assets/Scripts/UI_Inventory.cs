using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public static UI_Inventory Instance { get; private set; }
    public GameObject slotPrefab;
    public Transform slotsParent;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Refresh(List<ItemData> items)
    {
        foreach (Transform t in slotsParent)
            Destroy(t.gameObject);

        // create new slots
        foreach (var item in items)
        {
            var slot = Instantiate(slotPrefab, slotsParent);
            slot.GetComponent<Image>().sprite = item.icon;
        }
    }

    void OnEnable()
    {
        Refresh(InventoryManager.Instance.Items);
    }
}
