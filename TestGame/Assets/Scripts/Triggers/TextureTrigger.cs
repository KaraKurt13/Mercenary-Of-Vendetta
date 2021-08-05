using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTrigger : MonoBehaviour
{
    [SerializeField] GameObject TextureObj;
    [SerializeField] bool ShowMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.isTrigger)
        {
            if (TextureObj == null)
            {
                Destroy(this.gameObject);
                return;
            }

            switch (ShowMask)
            {
                case true:
                    {
                        TextureObj.SetActive(true);
                        this.gameObject.GetComponent<ChangeSceneAttributes>().ChangeAttributes();
                        break;
                    }
                case false:
                    {
                        TextureObj.SetActive(false);
                        this.gameObject.GetComponent<ChangeSceneAttributes>().ChangeAttributes();
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
