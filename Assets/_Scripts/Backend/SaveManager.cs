using System.IO;
using UnityEngine;

public static class SaveManager
{
    public static string SavePath = Application.persistentDataPath + "/save.dat";
    public static string SaveSettingsPath = Application.persistentDataPath + "/settings.dat";
    public static void SaveData(saveData save)
    {
        string json = JsonUtility.ToJson(save, true);
        File.WriteAllText(SavePath, json);
    }
    public static saveData LoadData(saveData def)
    {
        saveData newData;
        if (!File.Exists(SavePath))
        {
            newData = def ?? newSave();
            SaveData(newData);
            return newData;
        }
        string json = File.ReadAllText(SavePath);
        newData = JsonUtility.FromJson<saveData>(json);
        return newData ?? newSave();
    }
    public static saveData newSave()
    {
        saveData newS = new saveData();
        newS.inventory.inventory.Add(new itemSave { id = 0, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 1, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 2, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 3, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 4, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 5, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 6, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 7, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 8, count = 10 });
        newS.inventory.inventory.Add(new itemSave { id = 9, count = 10 });
        newS.inventory.unlockedItems.AddRange(System.Linq.Enumerable.Range(0, 10));
        newS.lastVendingMachine = 0;
        newS.machines.Add(new vendingData { id = 0, baseItems = (int[])startingInv.Clone(), nextItems = (int[])startingInv.Clone(), isUnlocked = true, upgrades = new System.Collections.Generic.List<skillsSave>() });
        return newS;
    }
    public static readonly int[] startingInv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static void SaveSettings()
    {
        settingsData newS = new settingsData();
        string json = JsonUtility.ToJson(newS, true);
        File.WriteAllText(SaveSettingsPath, json);
    }
    public static settingsData LoadSettings()
    {
        settingsData newData;
        if (!File.Exists(SaveSettingsPath))
        {
            newData = newSettings();
            string jsonX = JsonUtility.ToJson(newData, true);
            File.WriteAllText(SaveSettingsPath, jsonX);
            return newData;
        }
        string json = File.ReadAllText(SaveSettingsPath);
        newData = JsonUtility.FromJson<settingsData>(json);
        return newData ?? newSettings();
    }
    public static settingsData newSettings()
    {
        settingsData newS = new settingsData();
        return newS;
    }
}