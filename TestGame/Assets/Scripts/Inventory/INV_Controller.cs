using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class INV_Controller : MonoBehaviour
{
    [SerializeField] GameObject[] Slots_Image; // SLOTS
    [SerializeField] GameObject[] Slots_Amount;

    [SerializeField] GameObject Object_Description; // DESCRIPTION
    [SerializeField] GameObject Item_Description;
    [SerializeField] GameObject Item_Description_Name;
    [SerializeField] GameObject Item_Description_Image;
    [SerializeField] GameObject Use_Button;

    [SerializeField] GameObject Player; 
    [SerializeField] GameObject PlayerInterface;

    [SerializeField] GameObject Message_Item_Name; // NEW ITEM MESSAGE
    [SerializeField] GameObject Message_Item_Image;
    [SerializeField] GameObject NewItem;

    [SerializeField] GameObject NoNotes; // NOTES
    [SerializeField] GameObject Note_Object;
    [SerializeField] GameObject Note_Text;
    [SerializeField] GameObject Note_Count;
    [SerializeField] GameObject Button_Next;
    [SerializeField] GameObject Button_Previous;

    public Items_Info Items_Data; // Take item data
    public Notes_Info Notes_Data; // Take notes data
    public INV_Info Inventory_Information; // Put data

    private TMP_Text text_name; 
    private TMP_Text text_item_amount;
    private TMP_Text text_description;
    private TMP_Text note_text_count;
    private TMP_Text note_text_obj;

    private TextMeshProUGUI message_name;
    private Image message_image;

    private Image item_description_sprite;
    private Image item_slot_sprite;

    public int current_note=1;

    private BoxCollider2D PlayerBox;

    void Start()
    {
        SetInventory();
        message_name = Message_Item_Name.GetComponent<TextMeshProUGUI>();
        message_image = Message_Item_Image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(int id,int amount)
    {
        for (int i = 0; i < 15; i++)
        {
            if (Inventory_Information.slot_filled[i] == true && Inventory_Information.slot_item_id[i] != id)
            {
                continue;
            }
            else
            {
                Inventory_Information.slot_filled[i] = true;
                Inventory_Information.slot_item_id[i] = id;
                Inventory_Information.slot_item_amount[i] += amount;
                ShowMessage(id);
                SetInventory();
                break;
            }
        }
    }

    public void RemoveItem(int id, int amount)
    {
        for(int i=0;i<15;i++)
        {
            if(Inventory_Information.slot_item_id[i]==id)
            {
                Inventory_Information.slot_item_amount[i] -= amount;
                UpdateInventory();
                break;
            }
        }

    }

    void UpdateInventory()
    {
        for(int i=0;i<15;i++)
        {
            if (Inventory_Information.slot_filled[i] == true)
            {
                text_item_amount.SetText(Inventory_Information.slot_item_amount[i].ToString());
                if (Inventory_Information.slot_item_amount[i] == 0)
                {
                    Inventory_Information.slot_filled[i] = false;
                    Inventory_Information.slot_item_id[i] = 0;
                    Object_Description.SetActive(false);
                    Slots_Amount[i].SetActive(false);
                    Slots_Image[i].SetActive(false);
                    break;
                }
            }
            else
            {
                // Сортировка мб
            }
        }
    }
    public void SetInventory()
    {
        for(int i=0;i<15;i++)
        {
            if (Inventory_Information.slot_filled[i] == true)
            {
                Slots_Image[i].SetActive(true);
                item_slot_sprite = Slots_Image[i].GetComponent<Image>();
                item_slot_sprite.sprite = Items_Data.item_image[Inventory_Information.slot_item_id[i]];

                Slots_Amount[i].SetActive(true);
                text_item_amount = Slots_Amount[i].GetComponent<TextMeshProUGUI>();
                text_item_amount.SetText(Inventory_Information.slot_item_amount[i].ToString());
            }
            else
            {
                Slots_Image[i].SetActive(false);
                Slots_Amount[i].SetActive(false);
            }
        }
    }
    public void DisplayDescription(int Slot_ID)
    {
        Object_Description.SetActive(true);
        Button UseButton = Use_Button.GetComponent<Button>();
        text_description = Item_Description.GetComponent<TextMeshProUGUI>();
        text_name = Item_Description_Name.GetComponent<TextMeshProUGUI>();
        item_description_sprite = Item_Description_Image.GetComponent<Image>();


        int item_ID = Inventory_Information.slot_item_id[Slot_ID];
        text_description.SetText(Items_Data.item_description[item_ID]);
        text_name.SetText(Items_Data.item_name[item_ID]);
        item_description_sprite.sprite = Items_Data.item_image[item_ID];

        if (Items_Data.item_use[item_ID] == true)
        {
            Use_Button.SetActive(true);
            UseButton.onClick.RemoveAllListeners();
            UseButton.onClick.AddListener(delegate { ItemUse(item_ID); });
        }
        else
        {
            Use_Button.SetActive(false);
        }
    }

    public void ShowMessage(int item_id)
    {
        Player.GetComponent<CharacterControll>().enabled = false;
        PlayerInterface.SetActive(false);
        Message_Item_Name.GetComponent<TextMeshProUGUI>().SetText(Items_Data.item_name[item_id]);
        Message_Item_Image.GetComponent<Image>().sprite = Items_Data.item_image[item_id];
        NewItem.SetActive(true);
    }
    public void CloseMessage()
    {
        Player.GetComponent<CharacterControll>().enabled = true;
        PlayerInterface.SetActive(true);
        NewItem.SetActive(false);
    }

    public void AddNote(int Note_ID)
    {
        Inventory_Information.notes_list.Add(Note_ID);
    }
    public void RemoveNote(int Note_ID)
    {
        Inventory_Information.notes_list.Remove(Note_ID);
    }
    public void UpdateNotesInfo()
    {
        if (Inventory_Information.notes_list.Count == 0)
        {
            Note_Object.SetActive(false);
            NoNotes.SetActive(true);
            return;
        }
        else
        {
            Note_Object.SetActive(true);
            NoNotes.SetActive(false);
            note_text_count = Note_Count.GetComponent<TextMeshProUGUI>();
            note_text_obj = Note_Text.GetComponent<TextMeshProUGUI>();
            note_text_count.SetText(current_note.ToString() + "/" + Inventory_Information.notes_list.Count.ToString());
            note_text_obj.SetText(Notes_Data.notes_text[Inventory_Information.notes_list[current_note-1]]);
            if (current_note+1 <= Inventory_Information.notes_list.Count)
            {
                Button_Next.SetActive(true);
            }
            else
            {
                Button_Next.SetActive(false);
            }
            if(current_note-1!=0)
            {
                Button_Previous.SetActive(true);
               
            }
            else
            {
                Button_Previous.SetActive(false);
            }
        }
    }
    public void ChangeNote(int change_id)
    {
        switch(change_id)
        {
            case 0:
                {
                    current_note -= 1;
                    UpdateNotesInfo();
                    break;
                }
            case 1:
                {
                    current_note += 1;
                    UpdateNotesInfo();
                    break;
                }
        }
    }





    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////// I  T  E  M         U  S  E ///////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ItemUse(int item_id)
    {
        Debug.Log(item_id);
        Debug.Log(Inventory_Information.LastTriggeredName);
        switch (item_id)
        {

            case 1:
                {
                    if (Inventory_Information.LastTriggeredName != null && Inventory_Information.LastTriggeredName == "ManorRuneSecret")
                    {
                        GameObject obj;
                        Unhide_Secret_Location secret_loc = Inventory_Information.LastTriggeredObject.GetComponent<Unhide_Secret_Location>();
                        secret_loc.Unlock_Secret();
                        obj = Inventory_Information.LastTriggeredObject;
                        //obj.GetComponent<Unhide_Secret_Location>().enabled = false;
                        RemoveItem(item_id, 1);
                        this.GetComponent<INV_Script>().CloseInventory();
                    }
                    break;
                }
            case 2:
                {
                    if (Inventory_Information.LastTriggeredName != null && Inventory_Information.LastTriggeredName == "ClosedCrimsternHouse")
                    {
                        GameObject obj;
                        obj = Inventory_Information.LastTriggeredObject;
                        obj.GetComponent<EnterSublocation>().enabled = true;
                        obj.GetComponent<Dialog>().enabled = false;
                        RemoveItem(item_id, 1);
                        RemoveNote(2);
                        this.GetComponent<INV_Script>().CloseInventory();
                    }
                    break;
                }
            case 5:
                {
                    if (Inventory_Information.LastTriggeredName != null && Inventory_Information.LastTriggeredName == "BasementDoor")
                    {
                        GameObject obj;
                        obj = Inventory_Information.LastTriggeredObject;
                        obj.SetActive(false);
                        RemoveItem(item_id, 1);
                        RemoveNote(3); 
                        
                        this.GetComponent<INV_Script>().CloseInventory();
                    }
                    break;

                }
            case 6:
                {
                    if (Inventory_Information.LastTriggeredName != null && Inventory_Information.LastTriggeredName == "GardenDoor")
                    {
                        GameObject obj;
                        obj = Inventory_Information.LastTriggeredObject;
                        obj.SetActive(false);
                        RemoveItem(item_id, 1);
                        RemoveNote(4); 
                        this.GetComponent<INV_Script>().CloseInventory();
                    }
                    break;
                }
        }
        
    }

}
