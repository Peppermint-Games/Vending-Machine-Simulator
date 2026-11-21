using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingUIHolder : MonoBehaviour
{
    public Image holderImg;
    public itemData itemDat;
    public Sprite defaults;
    public void StoreRef()
    {
        holderImg.sprite = defaults;
    }
    public void ClearRef()
    {
        holderImg.sprite = itemDat.sprite;
    }
    public void OnMouseUp() => VendingUI.I.EndDrag(this);
}