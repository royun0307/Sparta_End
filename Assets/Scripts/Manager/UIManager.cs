using System.Collections.Generic;
using UnityEngine;

enum UIList
{
    UIMainMenu,
    UIStatus,
    UIInventory,
    UIInformation
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private List<UIPopup> popups = new List<UIPopup>();

    public Transform popup_parent;//팝업이 생성될 때 부모

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public T ShowPopup<T>() where T : UIPopup
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    public UIPopup ShowPopup(string popupName)
    {
        UIPopup existingPopup = popups.Find(p => p.GetType().Name == popupName);
        if (existingPopup != null)//팝업이 존재하면
        {
            if (!existingPopup.gameObject.activeSelf)//active가 false이면
                existingPopup.gameObject.SetActive(true);

            //리스트에서 인덱스 0으로 변경
            popups.Remove(existingPopup);
            popups.Insert(0, existingPopup);
            return existingPopup;
        }

        var obj = Resources.Load($"UI/Prefabs/{popupName}", typeof(GameObject)) as GameObject;//프리펩 로드
        if (!obj)//예외처리
        {
            Debug.LogWarning($"Failed to ShowPopup({popupName})");
            return null;
        }

        return ShowPopupWithPrefab(obj);
    }

    private UIPopup ShowPopupWithPrefab(GameObject prefab)
    {
        var obj = Instantiate(prefab, popup_parent);//생성
        return ShowPopup(obj);
    }

    private UIPopup ShowPopup(GameObject obj)
    {
        var popup = obj.GetComponent<UIPopup>();
        popups.Insert(0, popup);

        obj.SetActive(true);
        return popup;
    }
}