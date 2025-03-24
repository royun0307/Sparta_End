using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;

    public UIInventory inventory;
    public Button button;
    public Image icon;
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

    public void Set()
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

    public void OnClickButton()
    {
        if (item != null)
        {
            if (item is EquipmentData data)
            {
                if (!equipped)
                {
                    GameManager.Instance.Player.equipmentManager.Equip(data);
                }
                else
                {
                    GameManager.Instance.Player.equipmentManager.Unequip(data);
                }
            }
        }
        inventory.setSlots();
    }
}