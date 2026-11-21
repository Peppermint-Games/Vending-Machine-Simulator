using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager I;
    private void Awake() => I = this;

    [Header("Database")]
    public List<itemRef> allItems = new List<itemRef>();
    public int itemsCount;
    public ItemDatabase database;

    [Header("Inventory")]
    public List<itemSave> invRef = new List<itemSave>();

    private void Start()
    {
        GenerateDatabase();
        RefreshInventory();
    }

    public void GenerateDatabase()
    {
        allItems.Clear();
        for (int i = 0; i < itemsCount; i++)
        {
            itemData data = GenerateData(i);
            if (data == null)
                continue;
            allItems.Add(new itemRef { data = data, refImg = data.sprite });
        }
    }
    public itemData GenerateData(int id)
    {
        return ItemDatabase.newItem(id);
    }
    public void RefreshInventory()
    {
        invRef = GameManager.I.save.inventory.inventory;
    }
    public bool ModifyItemCount(int id, int count)
    {
        if (count == 0)
            return true;
        List<itemSave> inventory = GameManager.I.save.inventory.inventory;
        itemSave existingItem = inventory.Find(x => x.id == id);
        if (existingItem != null)
        {
            int newCount = existingItem.count + count;
            if (newCount < 0)
                return false;
            if (newCount == 0)
                inventory.Remove(existingItem);
            else
                existingItem.count = newCount;
        }
        else
        {
            if (count < 0)
                return false;
            inventory.Add(new itemSave { id = id, count = count });
        }
        if (count > 0)
            UnlockItem(id);
        RefreshInventory();
        return true;
    }
    public void UnlockItem(int id)
    {
        List<int> unlocked = GameManager.I.save.inventory.unlockedItems;
        if (!unlocked.Contains(id))
            unlocked.Add(id);
    }
    public int GetItemCount(int id)
    {
        itemSave item = invRef.Find(x => x.id == id);
        return item != null ? item.count : 0;
    }
    public bool HasItem(int id, int requiredCount = 1)
    {
        return GetItemCount(id) >= requiredCount;
    }
    public itemData GetItemData(int id)
    {
        itemRef item = allItems.Find(x => x.data.id == id);

        return item != null ? item.data : null;
    }
}
public class itemData
{
    public int id, val = 10;
    public string itemName, itemDescription;
    public vendingType vType = vendingType.Generic;
    public Sprite sprite = Resources.Load<Sprite>("Icons/Placeholder");
}
