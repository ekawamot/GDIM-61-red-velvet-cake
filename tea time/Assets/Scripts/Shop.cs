using UnityEngine;

public class Shop : MonoBehaviour
{
    public ItemData itemA;
    public ItemData itemB;

    public ItemData rewardItem;

    public KeyCode tradeKey = KeyCode.T;

    void Update()
    {
        if (Input.GetKeyDown(tradeKey))
        {
            Trade();
        }
    }

    public void Trade()
    {
        var inv = InventoryManager.Instance;

        if (inv.HasItem(itemA) && inv.HasItem(itemB))
        {
            inv.RemoveItem(itemA);
            inv.RemoveItem(itemB);
            inv.AddItem(rewardItem);
            Debug.Log($"Trade success! {itemA.itemName} + {itemB.itemName} → {rewardItem.itemName}");
        }
        else
        {
            Debug.Log($"You need both {itemA.itemName} and {itemB.itemName} to trade.");
        }
    }
}