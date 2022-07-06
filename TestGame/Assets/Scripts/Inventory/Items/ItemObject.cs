using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    private BoxCollider2D PlayerBox;
    private BoxCollider2D TriggerBox;
    private INV_Controller InventoryController;
    public int item_id;
    public int item_amount;

    private void Start()
    {
        PlayerBox = PlayerObj.GetComponent<BoxCollider2D>();
        TriggerBox = this.GetComponent<BoxCollider2D>();
        InventoryController = PlayerObj.GetComponentInChildren<INV_Controller>(true);
    }
    private void Update()
    {
        if (PlayerBox.IsTouching(TriggerBox)) // Якщо перетинається тригер
        {
            if(Input.GetKeyUp(KeyCode.E)) // Та натискається клавіша миші
            {
                InventoryController.AddItem(item_id, item_amount); // То необхідно добавити предмет в інвентар
                if(this.gameObject.GetComponent<ChangeSceneAttributes>()!=null) // Якщо присутній скрипт ChangeSceneAttributes
                {
                    this.gameObject.GetComponent<ChangeSceneAttributes>().ChangeAttributes(); // То змінити атрибути
                }
                Destroy(gameObject); // Та знищити предмет
            }
        }
        
    }

}
