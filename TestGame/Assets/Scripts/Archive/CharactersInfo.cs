using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CharactersInfo : ScriptableObject
{
    public int[] CharacterTypeID; // 0 - NPC, 1 - Торговец
    public string[] CharacterName;
    public string[] CharacterDescription;
    public bool[] CharacterIsDiscovered;
    public int[] CharacterRelationship;
    public Sprite[] CharacterSprite;
    public Sprite[] CharacterUnknownSprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
