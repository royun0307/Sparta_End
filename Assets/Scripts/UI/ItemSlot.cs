using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;//아이템
    public UIInventory inventory;//인벤토리
    public Button button;//아이템 슬랏
    public Image icon;//아이콘
    private Outline outline;

    public int index;
    public bool equipped;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        button.onClick.AddListener(OnClickButton);
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set()//값 세팅
    {
        if (item != null)
        {
            icon.gameObject.SetActive(true);
            icon.sprite = item.icon;
            equipped = GameManager.Instance.Player.equipmentManager.IsEquipped(item as EquipmentData);
        }

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
    }

    public void OnClickButton()//클릭시
    {
        if (item != null)
        {
            item.OnClick();//현재 장비만 구현, 클릭시 장착
        }
        inventory.setSlots();
    }
}