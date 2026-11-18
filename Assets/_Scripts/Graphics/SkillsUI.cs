using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
    public static SkillsUI I;
    private void Awake()
    {
        I = this;
    }
    public Text refDescription;
}