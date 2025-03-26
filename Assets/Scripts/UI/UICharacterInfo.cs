using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UICharacterInfo : UIPopup
{
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI characterLevel;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI exp;
    [SerializeField] Image expBar;

    private void Start()
    {
        if (characterName == null)
        {
            Debug.LogError("charcaterNameText is null");
        }
        if (characterLevel == null)
        {
            Debug.LogError("charcaterLevelText is null");
        }
        if (gold == null)
        {
            Debug.LogError("goldText is null");

        }
        if (exp == null)
        {
            Debug.LogError("expText is null");
        }

        Set();
    }

    public void Set()
    {
        CharacterInfo characterInfo = GameManager.Instance.Player.characterInfo;
        characterName.text = characterInfo.characterName;
        characterLevel.text = characterInfo.level.ToString();
        gold.text = characterInfo.gold.ToString("N0");
        exp.text = characterInfo.exp.ToString() + "/" + characterInfo.totalExp.ToString();
        expBar.fillAmount = (float)characterInfo.exp / (float)characterInfo.totalExp;
    }
}
