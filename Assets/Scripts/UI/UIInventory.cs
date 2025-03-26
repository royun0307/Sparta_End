using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIPopup
{
    [SerializeField] Button backBtn;//뒤로가기 버튼
    Inventory inventory;//인벤토리

    [SerializeField] int slotSize;//슬롯 개수
    [SerializeField] Transform slotParent;
    [SerializeField] ItemSlot slot;
    [SerializeField] List<ItemSlot> slots = new List<ItemSlot>();

    private void Awake()
    {
        //예외 처리
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(OnBack);
        }
        else
        {
            Debug.LogError("backBtn is null");
        }

        inventory = GameManager.Instance.Player.inventory;

        //슬롯 동적 추가
        for (int i = 0; i < slotSize; i++)
        {
            ItemSlot tmp = Instantiate(slot, slotParent);
            tmp.inventory = this;
            slots.Add(tmp);
            slots[i].index = i;
        }
        setSlots();
    }

    public void setSlots()//슬롯 세팅
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

    private void OnBack()//뒤로 가기
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
    }
}