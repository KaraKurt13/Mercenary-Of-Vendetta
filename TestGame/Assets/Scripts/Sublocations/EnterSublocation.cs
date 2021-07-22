using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSublocation : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject LevelChanger;
    private BoxCollider2D Player_Box;
    private BoxCollider2D Trigger_Box;
    private SceneChange Level_Changer_Script;
    public int sublocation_id;

    void Start()
    {
        Trigger_Box = this.GetComponent<BoxCollider2D>();
        Player_Box = Player.GetComponent<BoxCollider2D>();
        Level_Changer_Script = LevelChanger.GetComponent<SceneChange>();
    }

    void Update()
    {
        if(Player_Box.IsTouching(Trigger_Box))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Level_Changer_Script.LevelChange(sublocation_id);
            }
        }
        
    }
}
