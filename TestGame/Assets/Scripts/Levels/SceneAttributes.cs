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
    public bool[] TriggerIsActive;

    public int[] defaultNpc;
    public bool[] defaultFight;
    public bool[] defaultDoor;
    public bool[] defaultSecret;
    public bool[] defaultMask;
    public bool[] defaultItem;
    public bool[] defaultSublocation;
    public int[] defaultUnique;
    public bool[] defaultTrigger;

    private void OnDisable()
    {
        
    }

    public void SetDefaultValues()
    {
        NpcDialogueProgress = defaultNpc;
        FightIsCompleted = defaultFight;
        DoorIsUnlocked = defaultDoor;
        SecretTextureIsDiscovered = defaultSecret;
        MaskTextureActivated = defaultMask;
        ItemIsPickedUp = defaultItem;
        SublocationIsUnlocked = defaultSublocation;
        UniqueLocationChanges = defaultUnique;
        TriggerIsActive = defaultTrigger;
    }
}

