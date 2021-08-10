using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAttributes : MonoBehaviour
{
    [SerializeField] SceneAttributes[] Attributes;
    public int[] AttributeID; // 0 - NPC; 1 - Fight; 2 - Door; 3 - Secret Texture; 4 - Mask Texture; 5 - Item; 6 - Sublocation; 7 - Map; 8 - Triggers.
    public int[] ObjectID;
    public int[] ChangeID;
    public void ChangeAttributes()
    {
        for(int i=0;i<AttributeID.Length;i++)
      switch(AttributeID[i])
        {
            case 0:
                {
                    ChangeNPCAttribute(i);
                    break;
                }
            case 1:
                {
                    ChangeFightAttribute(i);
                    break;
                }
            case 2:
                {
                    ChangeDoorAttribute(i);
                    break;
                }
            case 3:
                {
                    ChangeSecretTextureAttribute(i);
                    break;
                }
            case 4:
                {
                    ChangeMaskTextureAttribute(i);
                    break;
                }
            case 5:
                {
                    ChangeItemAttribute(i);
                    break;
                }
            case 6:
                {
                    ChangeSublocationAttribute(i);
                    break;
                }
                case 7:
                    {
                        ChangeMap(i);
                        break;
                    }
                case 8:
                    {
                        ChangeTrigger(i);
                        break;
                    }
            }
    }

    void ChangeNPCAttribute(int loop_num)
    {
        Attributes[loop_num].NpcDialogueProgress[ObjectID[loop_num]] = ChangeID[loop_num];
    }

    void ChangeFightAttribute(int loop_num)
    {
        switch(ChangeID[loop_num])
        {
            case 0:
                {
                    Attributes[loop_num].FightIsCompleted[ObjectID[loop_num]] = false;
                    break;
                }
            case 1:
                {
                    Attributes[loop_num].FightIsCompleted[ObjectID[loop_num]] = true;
                    break;
                }
        }
    }

    void ChangeDoorAttribute(int loop_num)
    {
        switch (ChangeID[loop_num])
        {
            case 0: // Lock Door
                {
                    Attributes[loop_num].DoorIsUnlocked[ObjectID[loop_num]] = false;
                    break;
                }
            case 1: // Unlock Door
                {
                    Attributes[loop_num].DoorIsUnlocked[ObjectID[loop_num]] = true;
                    break;
                }
        }
    }

    void ChangeSecretTextureAttribute(int loop_num)
    {
        switch (ChangeID[loop_num])
        {
            case 0: // Show Mask
                {
                    Attributes[loop_num].SecretTextureIsDiscovered[ObjectID[loop_num]] = false;
                    break;
                }
            case 1: // Hide Mask
                {
                    Attributes[loop_num].SecretTextureIsDiscovered[ObjectID[loop_num]] = true;
                    break;
                }
        }
    }
    
    void ChangeMaskTextureAttribute(int loop_num)
    {
        switch(ChangeID[loop_num])
        {
            case 0: // Show Mask
                {
                    Attributes[loop_num].MaskTextureActivated[ObjectID[loop_num]] = true;
                    break;
                }
            case 1: // Hide Mask
                {
                    Attributes[loop_num].MaskTextureActivated[ObjectID[loop_num]] = false;
                    break;
                }
        }
    }

    void ChangeItemAttribute(int loop_num)
    {
        switch(ChangeID[loop_num])
        {
            case 0:
                {
                    Attributes[loop_num].ItemIsPickedUp[ObjectID[loop_num]] = false;
                    break;
                }
            case 1:
                {
                    Attributes[loop_num].ItemIsPickedUp[ObjectID[loop_num]] = true;
                    break;
                }
        }
    }

    void ChangeSublocationAttribute(int loop_num)
    {
        switch (ChangeID[loop_num])
        {
            case 0:
                {
                    Attributes[loop_num].SublocationIsUnlocked[ObjectID[loop_num]] = false;
                    break;
                }
            case 1:
                {
                    Attributes[loop_num].SublocationIsUnlocked[ObjectID[loop_num]] = true;
                    break;
                }
        }
    }

    void ChangeMap(int loop_num)
    {
        return;
    }

    void ChangeTrigger(int loop_num)
    {
        switch(ChangeID[loop_num])
        {
            case 0:
                {
                    Attributes[loop_num].TriggerIsActive[ObjectID[loop_num]] = false;
                    break;
                }
            case 1:
                {
                    Attributes[loop_num].TriggerIsActive[ObjectID[loop_num]] = true;
                    break;
                }
        }
        return;
    }
}
