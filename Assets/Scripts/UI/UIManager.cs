using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //기본적인 형태의 싱글턴 입니다. 수정해보세요.
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private List<UIPopup> _popups = new List<UIPopup>();

    public Transform popup_parent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public T ShowPopup<T>() where T : UIPopup
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    public UIPopup ShowPopup(string popupName)
    {
        var obj = Resources.Load($"Prefabs/UI/{popupName}", typeof(GameObject)) as GameObject;
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
        _popups.Insert(0, popup);

        obj.SetActive(true);
        return popup;
    }

    //추가적으로 필요한 함수들 작성해보세요.
}