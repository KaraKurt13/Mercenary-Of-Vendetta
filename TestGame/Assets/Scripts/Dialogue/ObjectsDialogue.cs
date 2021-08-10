using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectsDialogue : MonoBehaviour
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
    private int current_responsePointer;
    private string[] dialogue_name;
    private char[] dialogue_responses;

    void Start()
    {
        person_Box = this.gameObject.GetComponent<BoxCollider2D>();
        player_Box = Player.GetComponent<BoxCollider2D>();
        info = this.gameObject.GetComponent<Dialogue_Info>();
        response_TMP = Response.GetComponent<TextMeshProUGUI>();
        ch_name_TMP = Character_Name.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(player_Box.IsTouching(person_Box) && InterfaceIsClear())
        {
            ActivationButtonCheck();
        }
    }

    private bool InterfaceIsClear()
    {
        if(Dialogue_Interface.activeSelf == false && MapInterface.activeSelf == false && InventoryInterface.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false;
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
        dialogue_name = info.character_name;
        dialogue_responses = info.responses[0].ToCharArray();
        if (info.responses[0] == "")
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
        string response = "";
        current_responsePointer++;
        ch_name_TMP.SetText(dialogue_name[(int)char.GetNumericValue(dialogue_responses[current_responsePointer])]);
        current_responsePointer += 2;
        for (int i = current_responsePointer; i < info.responses[0].Length; i++)
        {
            if (dialogue_responses[i] == '/')
            {
                current_responsePointer = i;
                break;
            }
            response = response + dialogue_responses[i].ToString();
        }

        response_TMP.SetText(response);
        Button_Continue.GetComponent<Button>().onClick.AddListener(delegate { NextResponse(); });

    }

    public void NextResponse()
    {
        string response = "";
        current_responsePointer++;
        if (current_responsePointer == info.responses[0].Length)
        {
            EndDialogue();
            return;
        }
        ch_name_TMP.SetText(dialogue_name[(int)char.GetNumericValue(dialogue_responses[current_responsePointer])]);
        current_responsePointer += 2;


        for (int i = current_responsePointer; i <= info.responses[0].Length; i++)
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

    void EndDialogue()
    {
        current_responsePointer = 0;
        Player.GetComponent<CharacterControll>().enabled = true;
        Dialogue_Interface.SetActive(false);
        Player_Interface.SetActive(true);
        Button_Continue.GetComponent<Button>().onClick.RemoveAllListeners();
    }

}
