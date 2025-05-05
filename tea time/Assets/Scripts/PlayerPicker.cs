using UnityEngine;
using UnityEngine.UI;

public class PlayerPicker : MonoBehaviour
{
    public Camera playerCamera;
    public float pickRange = 3f;

    public Image crosshair;
    public Text promptText;

    void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, pickRange))
        {
            var pickup = hit.collider.GetComponent<PickupItem>();
            if (pickup != null)
            {
                if (promptText) promptText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InventoryManager.Instance.AddItem(pickup.itemData);
                    Destroy(pickup.gameObject);
                }
                return;
            }
        }

        if (promptText) promptText.gameObject.SetActive(false);
    }
}
