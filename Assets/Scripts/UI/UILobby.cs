using UnityEngine;

public class UILobby : MonoBehaviour
{
    void Start()//로비 시작 화면
    {
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
        UIManager.Instance.ShowPopup(UIList.UIInformation.ToString());
    }
}