using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Locations : ScriptableObject
{
    public bool[] button_status;

    private void OnEnable()
    {
        button_status = new bool[3];
        for(int i=0;i<3;i++) 
        {
            button_status[i] = false;
        }
        button_status[2] = true;

    }

}
