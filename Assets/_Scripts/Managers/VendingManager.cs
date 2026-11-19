using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingManager : MonoBehaviour
{
    public static VendingManager I;
    public int curVendingMachine;
    #region UI

    #endregion
    private void Awake()
    {
        I = this;
    }
    public void loadVend()
    {
        VendingManager.I.curVendingMachine = GameManager.I.save.lastVendingMachine;
        VendingMachineRef.Setup(curVendingMachine);
    }
    public void ChangeItem(int index, int val) => VendingMachineRef.cur.nextItems[index] = val;
}