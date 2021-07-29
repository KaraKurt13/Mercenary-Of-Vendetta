using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterObject : MonoBehaviour
{
    [SerializeField] LettersInfo LettersList;
    [SerializeField] int letter_id;
    [SerializeField] GameObject PlayerObj;
    private BoxCollider2D PlayerBox;
    private BoxCollider2D TriggerBox;


    void Start()
    {
        PlayerBox = PlayerObj.GetComponent<BoxCollider2D>();
        TriggerBox = this.GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if (PlayerBox.IsTouching(TriggerBox))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                AddLetter(letter_id);
                Destroy(gameObject);
            }
        }
    }
    void AddLetter(int letter_id)
    {
        LettersList.LettersIsDiscovered[letter_id] = true;
    }

}
