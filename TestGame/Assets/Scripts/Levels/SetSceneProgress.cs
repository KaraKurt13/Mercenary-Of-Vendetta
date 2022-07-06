using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneProgress : MonoBehaviour
{
    [SerializeField] SceneAttributes SceneProgress; //Об'єкт атрибутів сцени
    [SerializeField] GameObject[] NPC_Objects; // Об'єкти персонажів
    [SerializeField] GameObject[] Fight_Objects; // Об'єкти битв
    [SerializeField] GameObject[] Door_Objects; // Об'єкти дверей
    [SerializeField] GameObject[] SecretTexture_Objects; // Об'єкти таємних текстур
    [SerializeField] GameObject[] MaskTexture_Objects; // Об'єкти текстур масок
    [SerializeField] GameObject[] Item_Objects; // Об'єкти предметів
    [SerializeField] GameObject[] Sublocation_Objects; // Об'єкти входів до підлокацій
    [SerializeField] GameObject[] Trigger_Objects; // Об'єкти тригерів
    void Start()
    {
        SetLocationProgress(); 
    }

    public void SetLocationProgress() // Встановлення прогресу локації
    {
        SetNpcProgress(); // Встановлення прогресу персонажів
        SetFightProgress();// Встановлення прогресу битв
        SetDoorsLock();// Встановлення прогресу дверей
        SetSecretTextures();// Встановлення прогресу таємних текстур
        SetMaskTextures();// Встановлення прогресу текстур масок
        SetItems();// Встановлення прогресу предметів
        SetSublocationLocks();// Встановлення прогресу доступності підлокацій
        SetTriggers();// Встановлення прогресу тригерів
        Debug.Log("Scene Loading Completed");
        
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
