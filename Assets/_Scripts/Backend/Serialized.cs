using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class saveData
{
    public List<int> skillsBook = new List<int>();
    public List<vendingData> machines = new List<vendingData>();
    public invData inventory;
}
[Serializable]
public class settingsData
{

}
[Serializable]
public class skillsSave
{
    public int val;
    public bool isUnlocked;
}
[Serializable]
public class invData{
public List<itemSave> inventory = new List<itemSave>();
public int soulEnergy;
}
[Serializable]
public class itemSave{
public int id, count;
}
[Serializable]
public class vendingData{
public int[10] baseItems;
public bool isUnlocked;
public List<skillsSave> upgrades = new List<skillsSave>();
}
