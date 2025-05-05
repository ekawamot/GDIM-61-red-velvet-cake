using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public class Recipe
    {
        public string recipeName;
        public ItemData ingredientA;
        public ItemData ingredientB;
        public ItemData resultItem;
    }

    public List<Recipe> recipes = new List<Recipe>();

    public GameObject shopPanel;
    public Transform buttonContainer;
    public Button recipeButtonPrefab;

    void Awake()
    {
        if (shopPanel           == null) Debug.LogError("[ShopManager] shopPanel is NOT assigned!");
        if (buttonContainer     == null) Debug.LogError("[ShopManager] buttonContainer is NOT assigned!");
        if (recipeButtonPrefab  == null) Debug.LogError("[ShopManager] recipeButtonPrefab is NOT assigned!");
    }

    void Start()
    {
        shopPanel.SetActive(false);
        Cursor.lockState  = CursorLockMode.Locked;
        Cursor.visible    = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            ToggleShop();
    }

    void ToggleShop()
    {
        bool opening = !shopPanel.activeSelf;
        shopPanel.SetActive(opening);

        if (opening)
        {
            // build buttons
            PopulateRecipeButtons();

            // disable player movement/look
            var fp = FindObjectOfType<FirstPersonController>();
            if (fp != null) fp.enabled = false;

            // unlock cursor so you can click UI
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
        else
        {
            // re-enable movement/look
            var fp = FindObjectOfType<FirstPersonController>();
            if (fp != null) fp.enabled = true;

            // lock cursor back
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
        }
    }

    void PopulateRecipeButtons()
    {
        foreach (Transform t in buttonContainer)
            Destroy(t.gameObject);

        foreach (var r in recipes)
        {
            Button btn = Instantiate(recipeButtonPrefab, buttonContainer);
            TMP_Text label = btn.GetComponentInChildren<TMP_Text>();
            if (label != null)
                label.text = r.recipeName;
            else
                Debug.LogError("[ShopManager] No TMP_Text found on recipeButtonPrefab!");

            btn.onClick.AddListener(() => TryCraft(r));
        }
    }

    void TryCraft(Recipe r)
    {
        var inv = InventoryManager.Instance;

        if (inv.HasItem(r.ingredientA) && inv.HasItem(r.ingredientB))
        {
            inv.RemoveItem(r.ingredientA);
            inv.RemoveItem(r.ingredientB);
            inv.AddItem(r.resultItem);
            Debug.Log($"[Shop] Crafted {r.resultItem.itemName}!");
            PopulateRecipeButtons();
        }
        else
        {
            Debug.Log($"[Shop] You need: {r.ingredientA.itemName} + {r.ingredientB.itemName}");
        }
    }
}
