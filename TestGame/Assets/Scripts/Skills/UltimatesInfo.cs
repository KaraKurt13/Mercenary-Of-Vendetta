using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UltimatesInfo : ScriptableObject
{
    public string[] UltimateName;
    public string[] UltimateDescription;
    public bool[] UltimateIsLearned;
    public bool[] UltimateIsEquiped;
    public Sprite[] UltimateSprite;
    public int[] FirstRequiredSkillID;
    public int[] SecondRequiredSkillID;
    public int[] ThirdRequiredSkillID;

}
