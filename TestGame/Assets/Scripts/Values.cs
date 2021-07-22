using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu]
public class Values : ScriptableObject
{
    public Vector3 playerPosition;

    private void OnEnable()
    {
        playerPosition = new Vector3(-167, 90, 0);
    }
    private void OnDisable()
    {
        playerPosition = default;
    }
}