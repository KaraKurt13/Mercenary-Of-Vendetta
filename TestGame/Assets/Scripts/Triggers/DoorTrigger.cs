using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject DoorObject;
    [SerializeField] bool LockDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            switch (LockDoor)
            {
                case true:
                    {
                        DoorObject.SetActive(true);
                        break;
                    }
                case false:
                    {
                        DoorObject.SetActive(false);
                        break;
                    }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            this.gameObject.SetActive(false);

        }
    }
}
