using System.Collections.Generic;

public class SkillsDatabase
{
    public static skillDat newSkill(int id)
    {
        skillDat newS = new skillDat();
        newS.id = id;
        newS.prevSkill = 0;
        switch (id)
        {
            case 000:
                newS.prevSkill = -1;
                newS.skillName = "Skills";
                newS.description = "Unlock Skills";
                newS.type = skillType.Utility;
                break;
            case 001:
                newS.skillName = "Camera";
                newS.description = "Unlock Camera";
                newS.type = skillType.Utility;
                break;
            case 002:
                newS.prevSkill = 1;
                newS.skillName = "PTZ Camera";
                newS.description = "Unlock moveable Camera";
                newS.type = skillType.Utility;
                break;
        }
        return newS;
    }
}