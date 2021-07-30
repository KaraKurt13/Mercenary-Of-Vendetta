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
            this.gameObject.GetComponent<Dialog>().StartDialogue();
            this.gameObject.SetActive(false);
        }
       
    }
    

}
