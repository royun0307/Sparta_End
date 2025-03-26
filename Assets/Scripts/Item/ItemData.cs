using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public Sprite icon;//아이콘
    public string itemName;//아이템 이름
    public string description;//설명

    public virtual void OnClick() { }
}