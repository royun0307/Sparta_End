using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobby : MonoBehaviour
{
    void Start()
    {
        Transform tf = UIManager.Instance.ShowPopup(UIList.UIMainMenu.ToString()).GetComponent<Transform>();
    }
}
