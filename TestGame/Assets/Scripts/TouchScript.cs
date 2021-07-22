using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchScript : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public GameObject door_opened;
    [SerializeField] public GameObject door_closed;
    bool door_is_closed;

    private BoxCollider2D player_box;
    private BoxCollider2D object_box;
    private TMP_Text object_text;
    
    
    void Start()
    {
        if (door_closed.activeSelf == true) { door_is_closed = true; } else { door_is_closed = false; }

        player_box = player.GetComponent<BoxCollider2D>();
        object_box = GetComponent<BoxCollider2D>();
        object_text = text.GetComponent<TMP_Text>();
        
    }

    
    void Update()
    {
        object_text.enabled = false;

        if (player_box.IsTouching(object_box))
        {
          object_text.enabled = true;
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (door_is_closed == true)
                {
                    door_closed.SetActive(false);
                    door_opened.SetActive(true);
                    door_is_closed = false;
                }
                else
                {
                    door_closed.SetActive(true);
                    door_opened.SetActive(false);
                    door_is_closed = true;
                }
            }

        }
    }
}
