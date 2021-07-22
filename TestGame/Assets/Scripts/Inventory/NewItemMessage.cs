using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewItemMessage : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerInterface;
    [SerializeField] GameObject ItemName;
    [SerializeField] GameObject ItemImage;

    public Items_Info ItemsInfo;
                        public CharacterControll MoveScript;
                        public TextMeshProUGUI item_name;
                        public Image item_image;
    
    void Start()
    {
        MoveScript = Player.GetComponent<CharacterControll>();
        item_name = ItemName.GetComponent<TextMeshProUGUI>();
        item_image = ItemImage.GetComponent<Image>();
    }

    
}
