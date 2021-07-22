using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INV_Script : MonoBehaviour
{
    [SerializeField] GameObject InventoryInterface;
    [SerializeField] GameObject PlayerInterface;
    [SerializeField] GameObject DescriptionObject;

    INV_Controller Inventory;

    public void OpenInventory()
    {
        Inventory = InventoryInterface.GetComponent<INV_Controller>();
        Inventory.UpdateNotesInfo();
        InventoryInterface.SetActive(true);
        PlayerInterface.SetActive(false);
    }
    public void CloseInventory()
    {
        InventoryInterface.SetActive(false);
        DescriptionObject.SetActive(false);
        PlayerInterface.SetActive(true);
        Inventory.current_note = 1;
    }
}
