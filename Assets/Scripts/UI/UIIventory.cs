using UnityEngine;
using UnityEngine.UI;

public class UIIventory : UIPopup
{
    [SerializeField] Button back_Btn;

    private void Awake()
    {
        back_Btn.onClick.AddListener(OnBack);    
    }

    private void OnBack()
    {
        this.Hide();
    }
}
