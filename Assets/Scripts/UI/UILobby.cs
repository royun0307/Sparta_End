using UnityEngine;

public class UILobby : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
    }
}