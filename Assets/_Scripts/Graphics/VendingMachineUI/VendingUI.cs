using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingUI : MonoBehaviour
{
    public static VendingUI I;
    public itemData lastItem;
    private void Awake()
    {
        I = this;
    }
    public GameObject trackObj, holderObj;
    public bool dragging;
    public void StartDrag(VendingUIObject obj)
    {
        lastItem = obj.item;
        dragging = true;
        trackObj = Instantiate(trackObj);
        trackObj.GetComponent<VendingUIDrag>().Setup(obj.item);
    }
    public void EndDrag(VendingUIHolder dragged)
    {
        Vector3[] cornersA = new Vector3[4];
        Vector3[] cornersB = new Vector3[4];
        trackObj.GetComponent<RectTransform>().GetWorldCorners(cornersA);
        dragged.gameObject.GetComponent<RectTransform>().GetWorldCorners(cornersB);
        Rect worldRectA = new Rect(cornersA[0], cornersA[2] - cornersA[0]);
        Rect worldRectB = new Rect(cornersB[0], cornersB[2] - cornersB[0]);
        if (worldRectA.Overlaps(worldRectB))
            holderObj = dragged.gameObject;
        Destroy(trackObj);
        if (holderObj == null)
            return;
        //Remove item from inventory
        dragged.itemDat = trackObj.GetComponent<VendingUIDrag>().item;
        dragged.StoreRef();
        trackObj = null;
        holderObj = null;
        lastItem = null;
    }
}