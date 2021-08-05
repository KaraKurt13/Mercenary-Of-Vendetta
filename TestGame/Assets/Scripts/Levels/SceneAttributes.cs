using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneAttributes : ScriptableObject
{
    public int[] NpcDialogueProgress;
    public bool[] FightIsCompleted;
    public bool[] DoorIsUnlocked;
    public bool[] SecretTextureIsDiscovered;
    public bool[] MaskTextureActivated;
    public bool[] ItemIsPickedUp;
    public bool[] SublocationIsUnlocked;
    public int[] UniqueLocationChanges;

}
