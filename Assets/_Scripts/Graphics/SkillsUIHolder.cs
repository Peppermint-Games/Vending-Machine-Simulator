using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUIHolder : MonoBehaviour
{
    public Image unlockState;
    public skillLockType lockState = skillLockType.Locked;
    public int skillRef;
    skillDat data;
    private void Start()
    {
        data = SkillsDBManager.I.GenerateData(skillRef);
    }
    private void Update()
    {
        if (lockState == skillLockType.Locked)
        {
            if (SkillsDBManager.I.canPurchase(skillRef))
                lockState = skillLockType.Unlockable;
            if (SkillsDBManager.I.isUnlocked(skillRef))
                lockState = skillLockType.Unlocked;
        }
        if(lockState == skillLockType.Unlockable)
        {
            if (SkillsDBManager.I.isUnlocked(skillRef))
                lockState = skillLockType.Unlocked;
        }
        unlockState.GetComponent<SpriteRenderer>().color = lockState == skillLockType.Locked ? Color.black : lockState == skillLockType.Unlockable ? Color.red : Color.green;
    }
    public void OnClick()
    {
        SkillsUI.I.refDescription.text = data.description;
    }
}