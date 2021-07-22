using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class FightSettings : ScriptableObject
{
    public int enemies_count;
    public int[] enemies_id;
    public bool item_give;
    public int item_id;
    public Vector3 player_pos;
    public int scene_id;
    public GameObject FightObj;
    public int fight_id;
    public FightObjectsInfo FightObjInfo;

    private void OnDisable()
    {
        enemies_count = default;
        enemies_id = default;
        item_give = default;
        item_id = default;
        player_pos=default;
        scene_id=default;
        FightObj = default;
        fight_id = default;
        FightObjInfo = default;
}
}
