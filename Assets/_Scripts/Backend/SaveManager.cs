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
        return newS;
    }
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