using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FightObjectsInfo : ScriptableObject
{
    public bool[] FightIsCompleted;

    private void OnDisable()
    {
        for(int i=0;i<FightIsCompleted.Length;i++)
        {
            FightIsCompleted[i] = false;
        }
         
    }
}
