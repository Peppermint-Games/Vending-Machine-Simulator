using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public saveData save;
    private void Awake()
    {
        I = this;
    }
}