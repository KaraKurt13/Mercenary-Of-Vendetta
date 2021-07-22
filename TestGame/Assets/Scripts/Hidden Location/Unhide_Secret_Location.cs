using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unhide_Secret_Location : MonoBehaviour
{
    [SerializeField] GameObject Hidden_Texture;
    [SerializeField] GameObject Player_Obj;
    [SerializeField] GameObject Dialogue_Interface;
    [SerializeField] GameObject MapInterface;
    private BoxCollider2D trigger_collider;
    private BoxCollider2D player_box;

    void Start()
    {
        trigger_collider = this.GetComponent<BoxCollider2D>();
        player_box = Player_Obj.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_box.IsTouching(trigger_collider) && Dialogue_Interface.activeSelf == false && MapInterface.activeSelf == false)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Unlock_Secret();

            }
        }
    }
    public void Unlock_Secret()
    {
        Hidden_Texture.SetActive(false);
        Turn_Off_Script();
    }
    public void Turn_Off_Script()
    {
        this.GetComponent<Unhide_Secret_Location>().enabled = false;
    }
}
