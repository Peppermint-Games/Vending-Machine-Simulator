using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public saveData save;
    public settingsData settings;
    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }
        I = this;
        DontDestroyOnLoad(gameObject);
        save = SaveManager.LoadData(save);
        settings = SaveManager.LoadSettings();
        UpdateCurVend();
    }
    public void Save() => SaveManager.SaveData(save);
    public void SaveSettings() => SaveManager.SaveSettings();
    private void UpdateCurVend() => VendingManager.I.loadVend();
    public void AdvanceVendingMachine()
    {
        save.lastVendingMachine++;
        save.lastVendingMachine = Mathf.Clamp(save.lastVendingMachine, 0, save.machines.Count - 1);
        UpdateCurVend();
    }
    public void PreviousVendingMachine()
    {
        save.lastVendingMachine++;
        save.lastVendingMachine = Mathf.Clamp(save.lastVendingMachine, 0, save.machines.Count - 1);
        UpdateCurVend();
    }
    public void SetCurVendingMachine(int id)
    {
        save.lastVendingMachine = id;
        save.lastVendingMachine = Mathf.Clamp(save.lastVendingMachine, 0, save.machines.Count - 1);
        UpdateCurVend();
    }
}