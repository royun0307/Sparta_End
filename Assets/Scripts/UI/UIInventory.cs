using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIPopup
{
    [SerializeField] Button backBtn;

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
    }

    private void OnBack()
    {
        Hide();
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
    }
}