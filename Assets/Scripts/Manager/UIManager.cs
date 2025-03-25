using System.Collections.Generic;
using UnityEngine;

enum UIList
{
    UIMainMenu,
    UIStatus,
    UIInventory
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private List<UIPopup> popups = new List<UIPopup>();

    public Transform popup_parent;

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
        if (existingPopup != null)
        {
            if (!existingPopup.gameObject.activeSelf)
                existingPopup.gameObject.SetActive(true);

            popups.Remove(existingPopup);
            popups.Insert(0, existingPopup);
            return existingPopup;
        }

        var obj = Resources.Load($"UI/Prefabs/{popupName}", typeof(GameObject)) as GameObject;
        if (!obj)
        {
            Debug.LogWarning($"Failed to ShowPopup({popupName})");
            return null;
        }

        return ShowPopupWithPrefab(obj);
    }

    private UIPopup ShowPopupWithPrefab(GameObject prefab)
    {
        var obj = Instantiate(prefab, popup_parent);
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