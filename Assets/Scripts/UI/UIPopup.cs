using UnityEngine;

public class UIPopup : MonoBehaviour
{
    public virtual void Hide()//¼û±â±â
    {
        gameObject.SetActive(false);
    }
}
