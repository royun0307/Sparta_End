using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIPopup
{
    [SerializeField] Button statusBtn;//���� ��ư
    [SerializeField] Button inventoryBtn;//�κ��丮 ��ư
    [SerializeField] Transform parent;

    private void Awake()
    {
        //���� ó��
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

    private void OnStatus()//���� ����
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIStatus.ToString());
    }

    private void OnInventory()//�κ��丮 ����
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIInventory.ToString());
    }
}