using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class SkillsInfo : ScriptableObject
{
    public string[] SkillName;
    public string[] SkillDescription;
    public int[] SkillLevel;
    public bool[] SkillIsLearned;
    public bool[] SkillIsEquiped;
    public Sprite[] SkillSprite;

   
}
