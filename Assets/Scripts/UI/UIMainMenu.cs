using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIPopup
{
    [SerializeField] Button status_Btn;
    [SerializeField] Button inventory_Btn;
    [SerializeField] Transform parent;

    private void Awake()
    {
        status_Btn.onClick.AddListener(OnStatus);
        inventory_Btn.onClick.AddListener(OnInventory);
    }

    private void OnStatus()
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIStatus.ToString());
    }

    private void OnInventory()
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIInventory.ToString());
    }
}