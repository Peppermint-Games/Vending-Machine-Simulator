using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class saveData
{
    public List<int> skillsBook = new List<int>();
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