using UnityEngine;

public class UILobby : MonoBehaviour
{
    void Start()//�κ� ���� ȭ��
    {
        UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString());
        UIManager.Instance.ShowPopup(UIList.UIInformation.ToString());
    }
}