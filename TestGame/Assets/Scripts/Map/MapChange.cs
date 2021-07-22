using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChange : MonoBehaviour
{
    [SerializeField] Locations Locations_Info;
    public Button[] Location_Button; 
    
    private void Start()
    {
        MapStart();
    }

    private void MapStart()
    {
        for(int i=0;i<3;i++)
        {
            Location_Button[i].interactable = Locations_Info.button_status[i];
        }
    }
    public void Map_Change(int change_id,int location_id)
    {
        switch (change_id)
        {
            case 0: //Lock location
                {
                    Location_Button[location_id].interactable=false;
                    Locations_Info.button_status[location_id] = false;

                    break;
                }
            case 1: //Unlock location 
                {
                    Location_Button[location_id].interactable = true;
                    Locations_Info.button_status[location_id] = true;
                    break;
                }
        }
    }

}
