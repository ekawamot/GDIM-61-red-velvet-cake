using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public ItemData fishItemData;
    
    public float speed    = 2f;
    public float lifetime = 10f;
    private float timer   = 0f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifetime)
            Destroy(gameObject);
    }

    void OnMouseDown()
    {
        if (InventoryManager.Instance != null && fishItemData != null)
        {
            InventoryManager.Instance.AddItem(fishItemData);
        }
        else
        {
            Debug.LogWarning(
                "Missing InventoryManager.Instance or fishItemData on " + name
            );
        }
        Destroy(gameObject);
    }
}
