using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player_Interface;
    [SerializeField] GameObject MapInterface;
    [SerializeField] GameObject InventoryInterface;
    [SerializeField] GameObject Dialogue_Interface;
    [SerializeField] GameObject Character_Name;
    [SerializeField] GameObject Response;
    [SerializeField] GameObject Button_Continue;
    
    private BoxCollider2D person_Box;
    private BoxCollider2D player_Box;
    private Dialogue_Info info;
    private TMP_Text response_TMP;
    private TMP_Text ch_name_TMP;
    private int dialogue_size;
    private int current_response;
    public int map_change_value = 0;
    public int inventory_addItem = 0;
    public int inventory_removeItem = 0;
    public int item_id;
    public int item_amount;
    public int change_id;
    public int location_id;
    public int add_note;
    public int note_id;
    public int remove_note;
    public int remove_note_id;
    public bool DestroyThisDialogue;
    private string dialogue_name;
    private string[] dialogue_responses;


    private MapChange Map_Change;
    private INV_Controller Inv_Change;

    void Start()
    {
        Map_Change = MapInterface.GetComponent<MapChange>();
        Inv_Change = InventoryInterface.GetComponent<INV_Controller>();
        person_Box = this.gameObject.GetComponent<BoxCollider2D>();
        player_Box = Player.GetComponent<BoxCollider2D>();
        info = this.gameObject.GetComponent<Dialogue_Info>();
        response_TMP = Response.GetComponent<TextMeshProUGUI>();
        ch_name_TMP = Character_Name.GetComponent<TextMeshProUGUI>();
        dialogue_name = info.character_name;
        dialogue_responses = info.responses;
        dialogue_size = info.responses.Length;
        
    }
    void Update()
    {
        if (player_Box.IsTouching(person_Box) && Dialogue_Interface.activeSelf==false && MapInterface.activeSelf==false && InventoryInterface.activeSelf==false)
        {
            ActivationButtonCheck();
        }
    }

    void ActivationButtonCheck()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            StartDialogue();   
        }
    }

    public void StartDialogue()
    {
        Player.GetComponent<CharacterControll>().enabled = false;
        Player_Interface.SetActive(false);
        Dialogue_Interface.SetActive(true);
        current_response = 0;
        SetText();
    }

    public void SetText()
    {
        response_TMP.SetText(dialogue_responses[current_response]);
        ch_name_TMP.SetText(dialogue_name);
        Button_Continue.GetComponent<Button>().onClick.AddListener(delegate { NextResponse(); });
    }

    public void NextResponse()
    {
        Debug.Log(current_response);
        current_response++;

        //Debug.Log(current_response);
        if (current_response==dialogue_size)
        {
            EndDialogue();
            if (map_change_value == 1) { Map_Change.Map_Change(change_id, location_id); }
            if (inventory_addItem == 1) { Inv_Change.AddItem(item_id, item_amount); }
            if (inventory_removeItem == 1) { Inv_Change.RemoveItem(item_id, item_amount); }
            if (add_note == 1 && CheckNoteInventoryExist(note_id)==false) { Inv_Change.AddNote(note_id); }
            if (remove_note == 1) { Inv_Change.RemoveNote(remove_note_id); }

            return;
        }
        response_TMP.SetText(dialogue_responses[current_response], true);
    }
    
    bool CheckNoteInventoryExist(int note_id)
    {
        for(int i=0;i< Inv_Change.Inventory_Information.notes_list.Count; i++)
        {
            if (Inv_Change.Inventory_Information.notes_list[i] == note_id) { return true; }
        }
        return false;
    }
    void EndDialogue()
    {
        if (DestroyThisDialogue == true) { this.enabled = false; }
        Player.GetComponent<CharacterControll>().enabled = true;
        Dialogue_Interface.SetActive(false);
        Player_Interface.SetActive(true);
        Button_Continue.GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
