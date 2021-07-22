using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFightsOnScene : MonoBehaviour
{
    [SerializeField] FightObjectsInfo Fights_Info;
    [SerializeField] GameObject[] Fight_Objects;
    void Start()
    {
        for (int i = 0; i<Fights_Info.FightIsCompleted.Length; i++ )
        {
            Fight_Objects[i].SetActive(!Fights_Info.FightIsCompleted[i]);
        }
    }

}
