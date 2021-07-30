using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTextureTrigger : MonoBehaviour
{
    [SerializeField] GameObject MaskTexture;
    [SerializeField] bool ShowMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger)
        {
            switch(ShowMask)
            {
                case true:
                    {
                        MaskTexture.SetActive(true);
                        break;
                    }
                case false:
                    {
                        MaskTexture.SetActive(false);
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
