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
            case 003:
                newS.prevSkill = 0;
                newS.skillName = "Network Scan";
                newS.description = "Scan the local network for machine options";
                newS.type = skillType.Power;
                break;
            case 004:
                newS.prevSkill = 3;
                newS.skillName = "GPS Scan";
                newS.description = "Scan the local area for machine options";
                newS.type = skillType.Power;
                break;
            case 005:
                newS.prevSkill = 3;
                newS.skillName = "Possession";
                newS.description = "Possess target machine";
                newS.type = skillType.Power;
                break;
        }
        return newS;
    }
}
