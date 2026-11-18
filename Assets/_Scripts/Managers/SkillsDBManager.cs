using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsDBManager : MonoBehaviour
{
    public static SkillsDBManager I;
    public List<skillsSave> skillsBook = new List<skillsSave>();
    public int skillsCount;
    private void Awake()
    {
        I = this;
    }
    public SkillsDatabase database;
    private void Start()
    {
        for (int i = 0; i < skillsCount; i++)
            GenerateData(i);
        RefreshSkillsList();
    }
    public void RefreshSkillsList()
    {
        skillsBook.Clear();
        foreach (var item in GameManager.I.save.skillsBook)
            skillsBook.Add(new skillsSave { val = item, isUnlocked = true });
    }
    public skillDat GenerateData(int id)
    {
        return SkillsDatabase.newSkill(id);
    }
    public bool UnlockSkill(int id)
    {
        if (GameManager.I.save.skillsBook.Contains(id))
            return false;
        else
        {
            GameManager.I.save.skillsBook.Add(id);
            skillsBook.Add(new skillsSave { val = id, isUnlocked = true });
            return true;
        }
    }
    public bool isUnlocked(int id)
    {
        foreach (var item in skillsBook)
        {
            if (item.val == id)
                return true;
        }
        return false;
    }
    public bool canPurchase(int id)
    {
        skillDat refer = GenerateData(id);
        if (refer.id == 0)
            return true;
        if (isUnlocked(refer.prevSkill))
            return true;
        return false;
    }
}
public class skillDat
{
    public int id, prevSkill;
    public string skillName, description;
    public skillType type;
}