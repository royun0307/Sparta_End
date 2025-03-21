using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIPopup
{
    [SerializeField] Button backBtn;
    [SerializeField] StatUI attackUI;
    [SerializeField] StatUI defenceUI;
    [SerializeField] StatUI healthUI;
    [SerializeField] StatUI criticalUI;

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

        var playerStatus = GameManager.Instance.Player.status;

        if (attackUI != null)
            attackUI.Init(playerStatus.attack);
        if (defenceUI != null)
            defenceUI.Init(playerStatus.defence);
        if (healthUI != null)
            healthUI.Init(playerStatus.health);
        if (criticalUI != null)
            criticalUI.Init(playerStatus.critical);
    }

    private void OnBack()
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
    }
}
