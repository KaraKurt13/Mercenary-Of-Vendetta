using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapBlockTrigger : MonoBehaviour
{
    [SerializeField] bool BlockMapButton;
    [SerializeField] GameObject MapButton;

    private void OnTriggerEnter2D(Collider2D collision) //Метод спрацьовує при вході в певний 2D тригер
    {
        if(collision.isTrigger) //Якщо відбувається колізія з тригером, виконуємо код
        {
            switch(BlockMapButton) //В залежності від значення BlockMapButton, вирішуємо, чи блокувати кнопку "Мапи"
            {
                case true:
                    {
                        MapButton.GetComponent<Button>().interactable = false; //Блокування кнопки
                        break;
                    }
                case false:
                    {
                        MapButton.GetComponent<Button>().interactable = true; //Розблокування кнопки
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
