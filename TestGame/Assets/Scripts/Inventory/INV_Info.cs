using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class INV_Info : ScriptableObject
{

    public bool[] slot_filled;
    public int[] slot_item_id;
    public int[] slot_item_amount;
    public List<int> notes_list;
    public string LastTriggeredName;
    public GameObject LastTriggeredObject;

    void Start()
    {
;
    }

    private void OnDisable()
    {
        
        for(int i=0;i<15;i++)
        {
            slot_filled[i] = default;
            slot_item_amount[i] = default;
            slot_item_id[i] = default;
            
        }
        notes_list = default;
    }

    void Update()
    {
        
    }
}
