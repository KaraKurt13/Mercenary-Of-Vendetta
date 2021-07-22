using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Player_Info : ScriptableObject
{
    public float hp = 100;
    public float damage = 25;
    public int level;
    public int exp;
    public int skill_points;
    public int[] Skills_Id;
    public int Ultimate_Id;

  
}
