using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    private void OnDestroy()
    {
        this.gameObject.GetComponent<ChangeSceneAttributes>().ChangeAttributes();
    }
}
