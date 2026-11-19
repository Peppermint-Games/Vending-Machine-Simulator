using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VendingMachineRef
{
    public static vendingData cur;
    public static void Setup(int id) => cur = GameManager.I.save.machines.Find(x => x.id == id);
}