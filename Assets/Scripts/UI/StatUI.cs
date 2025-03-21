using TMPro;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    private BaseStatus baseStatus;

    public void Init(BaseStatus status)
    {
        baseStatus = status;
        baseStatus.OnValueChanged += UpdateUI;
        UpdateUI(baseStatus.value);
    }

    private void UpdateUI(float amount)
    {
        if (statText != null)
            statText.text = baseStatus.GetValueToString();
    }

    private void OnDestroy()
    {
        if (baseStatus != null)
            baseStatus.OnValueChanged -= UpdateUI;
    }
}
