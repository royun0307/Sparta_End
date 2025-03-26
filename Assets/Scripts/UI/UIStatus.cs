using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIPopup
{
    [SerializeField] Button backBtn;//�ڷΰ���
    [SerializeField] StatUI attackUI;//���ݷ�UI
    [SerializeField] StatUI defenceUI;//����UI
    [SerializeField] StatUI healthUI;//ü��UI
    [SerializeField] StatUI criticalUI;//ġ��ŸUI

    private void Awake()
    {
        //����ó��
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(OnBack);
        }
        else
        {
            Debug.LogError("backBtn is null");
        }

        var playerStatus = GameManager.Instance.Player.status;

        //����ó���� �ʱ�ȭ
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
