using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIPopup
{
    [SerializeField] Button statusBtn;//스탯 버튼
    [SerializeField] Button inventoryBtn;//인벤토리 버튼
    [SerializeField] Transform parent;

    private void Awake()
    {
        //예외 처리
        if (statusBtn != null)
        {
            statusBtn.onClick.AddListener(OnStatus);
        }
        else
        {
            Debug.LogError("statusBtn is null");
        }
        if (inventoryBtn != null)
        {
            inventoryBtn.onClick.AddListener(OnInventory);
        }
        else
        {
            Debug.LogError("inventoryBtn is null");
        }
    }

    private void OnStatus()//스탯 띄우기
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIStatus.ToString());
    }

    private void OnInventory()//인벤토리 띄우기
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIInventory.ToString());
    }
}