using System.Collections;
using System;
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
    [SerializeField] SceneAttributes SceneProgress;
    [SerializeField] GameObject SceneManager;
    
    private BoxCollider2D person_Box;
    private BoxCollider2D player_Box;
    private Dialogue_Info info;
    private TMP_Text response_TMP;
    private TMP_Text ch_name_TMP;

    private int current_responsePointer; // номер поточного символу у фразі
    private int NPC_ID; // ID персонажа
    private int NPC_Progress; // Прогрес діалогу з персонажем
    public int[] map_change_value; // Чи відбудеться зміна мапи
    public int[] inventory_addItem; // Чи додати предмет
    public int[] inventory_removeItem; // Чи видалити предмет
    public int[] item_id; // ID предмету
    public int[] item_amount; // Кількість предметів для видачі/видалення
    public string[] change_id; // Номер певної зміни (0 - закриття локації, 1 - відкриття)
    public string[] location_id; // Номер локації для зміни
    public int[] add_note; // Чи буде додаватись замітка
    public int[] note_id; // Номер замітки для додавання
    public int[] remove_note; // Чи буде видалятись замітка
    public int[] remove_note_id; // Номер замітки для видалення
    public bool[] change_npc_progress; // Зміна прогресу діалогу
    public int[] change_progress_num; // Номер прогресу, до якого перейде діалог після закінчення розмови
    private string[] dialogue_name; // Імена тих, хто бере участь у діалозі
    private char[] dialogue_responses; // Фрази


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
        NPC_Progress = SceneProgress.NpcDialogueProgress[NPC_ID];
        dialogue_name = info.character_name;
        dialogue_responses = info.responses[SceneProgress.NpcDialogueProgress[NPC_ID]].ToCharArray();
        if (info.responses[NPC_Progress] =="")
        {
            return;
        }
        Player.GetComponent<CharacterControll>().enabled = false;
        Player_Interface.SetActive(false);
        Dialogue_Interface.SetActive(true);
        current_responsePointer = 0;
        SetText();
    }

    public void SetText()
    {
        string response="";
        current_responsePointer++;
        ch_name_TMP.SetText(dialogue_name[(int)char.GetNumericValue(dialogue_responses[current_responsePointer])]);
        current_responsePointer+=2;
        for (int i = current_responsePointer; i < info.responses[NPC_Progress].Length; i++)
        {
            if(dialogue_responses[i]=='/')
            {
                current_responsePointer = i;
                break;
            }
            response=response+dialogue_responses[i].ToString();
        }
        
        response_TMP.SetText(response);
        Button_Continue.GetComponent<Button>().onClick.AddListener(delegate { NextResponse(); });



    }

    public void NextResponse()
    {
        string response = "";
        current_responsePointer++;
        if (current_responsePointer == info.responses[NPC_Progress].Length)
        {
            EndDialogue();
            if (map_change_value[NPC_Progress] == 1)
            {
                
                string[] string_loc_id;
                string[] string_change_id;
                string_loc_id = location_id[NPC_Progress].Split('/');
                string_change_id = change_id[NPC_Progress].Split('/');
                int[] loc_id = Array.ConvertAll<string, int>(string_loc_id, int.Parse);
                int[] chg_id = Array.ConvertAll<string, int>(string_change_id, int.Parse);
                for(int i=0;i<loc_id.Length;i++)
                {
                    Map_Change.Map_Change(chg_id[i], loc_id[i]);
                }
                
            }

            if (inventory_addItem[NPC_Progress] == 1) { Inv_Change.AddItem(item_id[NPC_Progress], item_amount[NPC_Progress]); } // Додавання предмету
            if (inventory_removeItem[NPC_Progress] == 1) { Inv_Change.RemoveItem(item_id[NPC_Progress], item_amount[NPC_Progress]); } // Видалення предмету
            if (add_note[NPC_Progress] == 1 && CheckNoteInventoryExist(note_id[NPC_Progress]) == false) { Inv_Change.AddNote(note_id[NPC_Progress]); }// Додавання замітки
            if (remove_note[NPC_Progress] == 1) { Inv_Change.RemoveNote(remove_note_id[NPC_Progress]); }// Видалення замітки
            if (change_npc_progress[NPC_Progress] == true ) { SceneProgress.NpcDialogueProgress[NPC_ID] = change_progress_num[NPC_Progress]; } // Зміна прогресу діалогу
            if(info.change_scene[NPC_Progress]==true) // Якщо необхідно внести великі зміни до сцени (DEL)
            {
                info.changeObjects[NPC_Progress].GetComponent<ChangeSceneAttributes>().ChangeAttributes(); // Використовується метод для зміни атрибутів сцени 
                SceneManager.GetComponent<SetSceneProgress>().SetLocationProgress(); //Зберігаються зміни до сцени
            }
            
            return;
        }

        ch_name_TMP.SetText(dialogue_name[(int)char.GetNumericValue(dialogue_responses[current_responsePointer])]);
        current_responsePointer+=2;
        

        for (int i = current_responsePointer; i <= info.responses[NPC_Progress].Length; i++)
        {
            if (dialogue_responses[i] == '/')
            {
                current_responsePointer = i;
                break;
            }
            response = response + dialogue_responses[i].ToString();
        }
        response_TMP.SetText(response);

        

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
        current_responsePointer = 0;
        Player.GetComponent<CharacterControll>().enabled = true;
        Dialogue_Interface.SetActive(false);
        Player_Interface.SetActive(true);
        Button_Continue.GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
