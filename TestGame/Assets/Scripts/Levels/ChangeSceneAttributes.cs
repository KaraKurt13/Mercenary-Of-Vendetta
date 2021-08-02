using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAttributes : MonoBehaviour
{
    public int AttributeID; // 0 - NPC; 1 - Fight; 2 - Door; 3 - Secret Texture; 4 - Mask Texture; 5 - Item; 6 - Sublocation.
    public int ObjectID;
    public int ChangeID;
    void Start()
    {
      switch(AttributeID)
        {
            case 0:
                {
                    ChangeNPCAttribute();
                    break;
                }
            case 1:
                {
                    ChangeFightAttribute();
                    break;
                }
            case 2:
                {
                    ChangeDoorAttribute();
                    break;
                }
            case 3:
                {
                    ChangeSecretTextureAttribute();
                    break;
                }
            case 4:
                {
                    ChangeMaskTextureAttribute();
                    break;
                }
            case 5:
                {
                    ChangeItemAttribute();
                    break;
                }
            case 6:
                {
                    ChangeSublocationAttribute();
                    break;
                }
        }
    }

    void ChangeNPCAttribute()
    {

    }

    void ChangeFightAttribute()
    {

    }

    void ChangeDoorAttribute()
    {

    }

    void ChangeSecretTextureAttribute()
    {

    }
    
    void ChangeMaskTextureAttribute()
    {

    }

    void ChangeItemAttribute()
    {

    }

    void ChangeSublocationAttribute()
    {

    }

}
