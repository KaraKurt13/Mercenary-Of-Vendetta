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
    [SerializeField] GameObject[] Trigger_Objects;
    void Start()
    {
        SetLocationProgress();
    }

    public void SetLocationProgress()
    {
        SetNpcProgress();
        SetFightProgress();
        SetDoorsLock();
        SetSecretTextures();
        SetMaskTextures();
        SetItems();
        SetSublocationLocks();
        SetTriggers();
        Debug.Log("Scene Loading Completed");
        //this.gameObject.SetActive(false);
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
                        Fight_Objects[i].SetActive(false);
                        break;
                    }
                case false:
                    {
                        Fight_Objects[i].SetActive(true);
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

        for(int i=0;i<Door_Objects.Length;i++)
        {
            switch(SceneProgress.DoorIsUnlocked[i])
            {
                case true:
                    {
                        Destroy(Door_Objects[i]);
                        break;
                    }
                case false:
                    {
                        Door_Objects[i].SetActive(true);
                        break;
                    }
            }
        }

    }

    void SetSecretTextures()
    {
        if(SecretTexture_Objects.Length == 0)
        {
            return;
        }

        for (int i = 0; i < SecretTexture_Objects.Length; i++)
        {
            switch (SceneProgress.SecretTextureIsDiscovered[i])
            {
                case true:
                    {
                        Destroy(SecretTexture_Objects[i]);
                        break;
                    }
                case false:
                    {
                        SecretTexture_Objects[i].SetActive(true);
                        break;
                    }
            }
        }

    }

    void SetMaskTextures()
    {
        if(MaskTexture_Objects.Length == 0)
        {
            return;
        }

        for(int i=0;i<MaskTexture_Objects.Length;i++)
        {
            switch (SceneProgress.MaskTextureActivated[i])
            {
                case true:
                    {
                        MaskTexture_Objects[i].SetActive(true);
                        
                        break;
                    }
                case false:
                    {
                        MaskTexture_Objects[i].SetActive(false);
                        break;
                    }
            }
        }
        

    }

    void SetItems()
    {
        if (Item_Objects.Length == 0)
        {
            return;
        }

        for (int i = 0; i < Item_Objects.Length; i++)
        {
            switch (SceneProgress.ItemIsPickedUp[i])
            {
                case true:
                    {
                        Destroy(Item_Objects[i]);
                        break;
                    }
                case false:
                    {
                        Item_Objects[i].SetActive(true);
                        break;
                    }
            }
        }
    }

    void SetSublocationLocks()
    {
        if(Sublocation_Objects.Length == 0)
        {
            return;
        }

        for (int i = 0; i < Sublocation_Objects.Length; i++)
        {
            switch (SceneProgress.SublocationIsUnlocked[i])
            {
                case true:
                    {
                        Sublocation_Objects[i].GetComponent<EnterSublocation>().enabled = true;
                        break;
                    }
                case false:
                    {
                        Sublocation_Objects[i].GetComponent<EnterSublocation>().enabled = false;
                        break;
                    }
            }
        }
    }

    void SetTriggers()
    {
        if(Trigger_Objects.Length==0)
        {
            return;
        }

        for(int i=0;i<Trigger_Objects.Length;i++)
        {
            switch(SceneProgress.TriggerIsActive[i])
            {
                case true:
                    {
                        Trigger_Objects[i].SetActive(true);
                        break;
                    }
                case false:
                    {
                        Trigger_Objects[i].SetActive(false);
                        break;
                    }
            }
        }
    }
}
