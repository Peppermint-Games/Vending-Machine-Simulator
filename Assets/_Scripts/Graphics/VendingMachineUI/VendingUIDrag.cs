using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingUIDrag : MonoBehaviour
{
    public VendingUIHolder storage;
    public itemData item;
    public Image holder;
    public void Setup(itemData data)
    {
        item = data;
        holder.sprite = data.sprite;
    }
}