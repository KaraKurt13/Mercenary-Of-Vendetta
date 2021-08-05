using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightSetup : MonoBehaviour
{
    [SerializeField] GameObject Player_Obj;
    [SerializeField] FightSettings Settings;
    [SerializeField] GameObject FightButtonObject;
    
    private Button FightButton;
    private BoxCollider2D PlayerCollider;
    private BoxCollider2D FightCollider;

    public int set_enemies_count;
    public int[] set_enemies_id;
    public bool set_item_give;
    public int set_item_id;
    public int set_fight_id;
    public SceneAttributes set_fightlocation;

    void Start()
    {
        FightButton = FightButtonObject.GetComponent<Button>();
        PlayerCollider = Player_Obj.GetComponent<BoxCollider2D>();
        FightCollider = this.gameObject.GetComponent<BoxCollider2D>();
        FightButton.onClick.AddListener(delegate { StartFight(); });
    }

    void Update()
    {
        if(PlayerCollider.IsTouching(FightCollider))
        {
            FightButtonObject.SetActive(true);
        }
        else
        {
            FightButtonObject.SetActive(false);
            
        }
    }
    void SetFightSettings()
    {
        Settings.enemies_count = set_enemies_count;
        Settings.enemies_id = set_enemies_id;
        Settings.item_give = set_item_give;
        Settings.item_id = set_item_id;
        Settings.player_pos = Player_Obj.transform.position;
        Settings.fight_id = set_fight_id;
        Settings.scene_id = SceneManager.sceneCount;
        Settings.FightObj = this.gameObject;
        Settings.FightLocation = set_fightlocation;
    }
    public void StartFight()
    {
        SetFightSettings();
        SceneManager.LoadScene(6);
    }
}
