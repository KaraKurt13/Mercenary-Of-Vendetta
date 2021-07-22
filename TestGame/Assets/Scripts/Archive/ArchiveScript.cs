using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArchiveScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerInterface;
    [SerializeField] GameObject ArchiveInterface;
    [SerializeField] GameObject[] PageButtons;
    [SerializeField] GameObject[] Pages;
    public int current_page;

    //Letters
    //Characters
    [SerializeField] GameObject[] CharactersImages;
    [SerializeField] GameObject CharacterDescriptionObject;
    [SerializeField] GameObject CharacterDescription_Name;
    [SerializeField] GameObject CharacterDescription_Type;
    [SerializeField] GameObject CharacterDescription_Story;
    [SerializeField] GameObject CharacterDescription_Relationship;
    [SerializeField] GameObject CharacterDescription_Image;
    [SerializeField] CharactersInfo CharactersInformation;
    //Enemies
    
    public void OpenArchive()
    {
        PlayerInterface.SetActive(false);
        UpdateArchive();
        ChangeArchivePage(0);
        ArchiveInterface.SetActive(true);

        CharacterDescriptionObject.SetActive(false);
    }

    public void CloseArchive()
    {
        PlayerInterface.SetActive(true);
        ArchiveInterface.SetActive(false);
    }
    
    public void ChangeArchivePage(int page_id)
    {
        PageButtons[current_page].GetComponent<Button>().interactable = true;
        PageButtons[page_id].GetComponent<Button>().interactable = false;
        
        Pages[current_page].SetActive(false);
        Pages[page_id].SetActive(true);
        
        current_page = page_id;
    }
    void UpdateLetters()
    {
        
    }

    void UpdateCharacters()
    {
        for(int i=0;i<3;i++)
        switch(CharactersInformation.CharacterIsDiscovered[i])
        {
            case true:
                {
                        CharactersImages[i].GetComponent<Image>().sprite = CharactersInformation.CharacterSprite[i];
                    break;
                }
            case false:
                {
                        CharactersImages[i].GetComponent<Image>().sprite = CharactersInformation.CharacterUnknownSprite[i];
                        break;
                }
        }
    }

    void UpdateEnemies()
    {

    }

    public void UpdateArchive()
    {
        UpdateLetters();
        UpdateCharacters();
        UpdateEnemies();
    }

    public void ShowCharacterDescription(int npc_id)
    {
        switch(CharactersInformation.CharacterIsDiscovered[npc_id])
        {
            case true:
                {
                    CharacterDescription_Name.GetComponent<TextMeshProUGUI>().SetText(CharactersInformation.CharacterName[npc_id]);
                    CharacterDescription_Type.GetComponent<TextMeshProUGUI>().SetText(CharacterType(CharactersInformation.CharacterTypeID[npc_id]));
                    CharacterDescription_Relationship.GetComponent<TextMeshProUGUI>().SetText(CharactersInformation.CharacterRelationship[npc_id].ToString() + "/100");
                    CharacterDescription_Story.GetComponent<TextMeshProUGUI>().SetText(CharactersInformation.CharacterDescription[npc_id]);
                    CharacterDescription_Image.GetComponent<Image>().sprite = CharactersInformation.CharacterSprite[npc_id];
                    break;
                }
            case false:
                {
                    CharacterDescription_Name.GetComponent<TextMeshProUGUI>().SetText("???");
                    CharacterDescription_Type.GetComponent<TextMeshProUGUI>().SetText("???");
                    CharacterDescription_Relationship.GetComponent<TextMeshProUGUI>().SetText("???/100");
                    CharacterDescription_Story.GetComponent<TextMeshProUGUI>().SetText("Неизвестный персонаж");
                    CharacterDescription_Image.GetComponent<Image>().sprite = CharactersInformation.CharacterUnknownSprite[npc_id];
                    break;
                }
        }
        CharacterDescriptionObject.SetActive(true);

            
    }

    string CharacterType(int id)
    {
        switch(id)
        {
            case 0:
                {
                    return "Персонаж";
                }
            case 1:
                {
                    return "Торговец";
                }
        }
        return null;
    }
    public void ShowEnemyDescriptipn(int enemy_id)
    {

    }

    public void NextLetter()
    {

    }

    
}
