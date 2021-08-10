using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger)
        {
            if (this.gameObject.GetComponent<Dialog>() == null)
            {
                this.gameObject.GetComponent<ObjectsDialogue>().StartDialogue();
            }
            else
            {
                this.gameObject.GetComponent<Dialog>().StartDialogue();
            }
            
            this.gameObject.SetActive(false);
        }
       
    }
    

}
