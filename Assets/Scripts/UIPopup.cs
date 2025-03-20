using UnityEngine;

public class UIPopup : MonoBehaviour
{
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
