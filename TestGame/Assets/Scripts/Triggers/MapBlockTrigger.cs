using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapBlockTrigger : MonoBehaviour
{
    [SerializeField] bool BlockMapButton;
    [SerializeField] GameObject MapButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger)
        {
            switch(BlockMapButton)
            {
                case true:
                    {
                        MapButton.GetComponent<Button>().interactable = false;
                        break;
                    }
                case false:
                    {
                        MapButton.GetComponent<Button>().interactable = true;
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
