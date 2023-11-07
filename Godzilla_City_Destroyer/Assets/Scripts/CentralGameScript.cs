using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptableObjects", menuName = "ScriptableObject/Scene")]
public class CentralGameScript : ScriptableObject
{
    public int winState = 255;
    public int currentState = 0;

    public int bossWinState = 999;

    public int arrayCheck = -1;

    public string[] levelNames = {"Level1_Boss", "Level2_City", "Level2_Boss", "EndScene"};

}
