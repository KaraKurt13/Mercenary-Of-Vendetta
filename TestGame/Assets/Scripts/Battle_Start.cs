using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Battle_Start : MonoBehaviour
{
    [SerializeField] public Unit_Info[] Enemies_Info;
    [SerializeField] public GameObject[] Enemies_Objects;
    
    


    void Start()
    {
        SpriteRenderer m_spriterender;
        TextMeshProUGUI Enemies_Text;
        TMP_Text m_text;

        for(int i=0;i<Enemies_Objects.Length;i++)
        {
            m_spriterender = Enemies_Objects[i].GetComponent<SpriteRenderer>();
            Enemies_Text = Enemies_Objects[i].GetComponentInChildren<TextMeshProUGUI>();
            m_text = Enemies_Text.GetComponent<TMP_Text>();
            m_text = Enemies_Objects[i].GetComponentInChildren<TMP_Text>();
            m_spriterender.sprite = Enemies_Info[i].enemy_sprite;
            m_text.SetText(Enemies_Info[i].enemy_name);
        }
        Debug.Log("Battle START!");
    }

    void Update()
    {
        
    }
}
