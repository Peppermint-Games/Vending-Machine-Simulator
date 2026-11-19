using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager I;
    void Awake() => I = this;
    public List<itemData> allItems = new List<itemData>();
    public List<itemSave> invRef = new List<itemSave>();
    public int itemsCount;
    public ItemDatabase database;
    void Start()
    {
        allItems.Clear();
        for (int i = 0; i < itemsCount; i++)
            allItems.Add(GenerateData(i));
        RefreshInventory();
    }
    public itemData GenerateData(int id)
    {
        return ItemDatabase.newItem(id);
    }
    public void RefreshInventory()
    {
        invRef.Clear();
        invRef = GameManager.I.save.inventory.inventory;
    }
    public void ModifyItemCount(int id, int count)
    {
        bool exists = false;
        foreach (var item in GameManager.I.save.inventory.inventory)
        {
            if (item.id == id)
            {
                if (item.count >= count && count < 0 || count > 0)
                {
                    item.count += count;
                    exists = true;
                }
            }
        }
        if (!exists)
        {
            GameManager.I.save.inventory.inventory.Add(new itemSave { id = id, count = count });
            UnlockItem(id);
        }
        RefreshInventory();
    }
    public void UnlockItem(int val) => GameManager.I.save.inventory.unlockedItems.Add(val);
}
public class itemData
{
    public int id, val = 10;
    public string itemName, itemDescription;
    public vendingType vType = vendingType.Generic;
}
