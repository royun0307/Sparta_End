using TMPro;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    private BaseStatus baseStatus;

    public void Init(BaseStatus status)
    {
        baseStatus = status;
        baseStatus.OnValueChanged += UpdateUI;//액션에 이벤트 추가
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
            baseStatus.OnValueChanged -= UpdateUI;//액션에 이벤트 제거
    }
}
