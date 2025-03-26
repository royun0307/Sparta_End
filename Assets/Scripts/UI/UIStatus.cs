using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIPopup
{
    [SerializeField] Button backBtn;//뒤로가기
    [SerializeField] StatUI attackUI;//공격력UI
    [SerializeField] StatUI defenceUI;//방어력UI
    [SerializeField] StatUI healthUI;//체력UI
    [SerializeField] StatUI criticalUI;//치명타UI

    private void Awake()
    {
        //예외처리
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(OnBack);
        }
        else
        {
            Debug.LogError("backBtn is null");
        }

        var playerStatus = GameManager.Instance.Player.status;

        //예외처리와 초기화
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
