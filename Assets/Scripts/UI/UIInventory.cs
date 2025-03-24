using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIPopup
{
    [SerializeField] Button backBtn;
    Inventory inventory;

    [SerializeField] int slotSize;
    [SerializeField] Transform slotParent;
    [SerializeField] ItemSlot slot;
    [SerializeField] List<ItemSlot> slots = new List<ItemSlot>();

    private void Awake()
    {
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(OnBack);
        }
        else
        {
            Debug.LogError("backBtn is null");
        }

        inventory = GameManager.Instance.Player.inventory;

        for (int i = 0; i < slotSize; i++)
        {
            ItemSlot tmp = Instantiate(slot, slotParent);
            tmp.inventory = this;
            slots.Add(tmp);
            slots[i].index = i;
        }
        setSlots();
    }

    public void setSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.inventory.Count)
            {
                slots[i].item = inventory.inventory[i];
            }
            slots[i].Set();
        }
    }

    private void OnBack()
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
    }
}