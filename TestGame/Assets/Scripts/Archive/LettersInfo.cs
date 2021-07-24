using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LettersInfo : ScriptableObject
{
    public bool[] LettersIsDiscovered;
    public string[] LetterName;
    public string[] LetterText;
}
