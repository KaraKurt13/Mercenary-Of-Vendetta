using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneProgress : MonoBehaviour
{
    [SerializeField] SceneAttributes SceneProgress;
    [SerializeField] GameObject[] NPC_Objects;
    [SerializeField] GameObject[] Fight_Objects;
    [SerializeField] GameObject[] Door_Objects;
    [SerializeField] GameObject[] SecretTexture_Objects;
    [SerializeField] GameObject[] MaskTexture_Objects;
    [SerializeField] GameObject[] Item_Objects;
    [SerializeField] GameObject[] Sublocation_Objects;
    void Start()
    {
        SetNpcProgress();
        SetFightProgress();
        SetDoorsLock();
        SetSecretTextures();
        SetMaskTextures();
        SetItems();
        SetSublocationLocks();
        Destroy(this.gameObject);
    }

    void SetNpcProgress()
    {
        if (NPC_Objects.Length == 0)
        {
            return;
        }

    }

    void SetFightProgress()
    {
        if(Fight_Objects.Length == 0)
        {
            return;
        }
        for(int i=0;i<Fight_Objects.Length;i++)
        {
            switch(SceneProgress.FightIsCompleted[i])
            {
                case true:
                    {
                        Destroy(Fight_Objects[i]);
                        break;
                    }
                case false:
                    {
                        Destroy(Fight_Objects[i]);
                        break;
                    }
            }
        }
    }
    
    void SetDoorsLock()
    {
        if(Door_Objects.Length == 0)
        {
            return;
        }

    }

    void SetSecretTextures()
    {
        if(SecretTexture_Objects.Length == 0)
        {
            return;
        }

    }

    void SetMaskTextures()
    {
        if(MaskTexture_Objects.Length == 0)
        {
            return;
        }



    }

    void SetItems()
    {
        if (Item_Objects.Length == 0)
        {
            return;
        }
    }

    void SetSublocationLocks()
    {
        if(Sublocation_Objects.Length == 0)
        {
            return;
        }
    }
}
