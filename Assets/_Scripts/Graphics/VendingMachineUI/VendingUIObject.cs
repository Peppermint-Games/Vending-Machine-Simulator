using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingUIObject : MonoBehaviour
{
    public itemData item;
    public void OnMouseDrag() => VendingUI.I.StartDrag(this);
}