using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTreeScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerInterface;
    [SerializeField] GameObject TreeInterface;
    [SerializeField] GameObject[] TreeButtons;
    [SerializeField] GameObject[] Trees;
    [SerializeField] GameObject[] Skills;
    [SerializeField] GameObject[] Ultimates;
    [SerializeField] GameObject[] SkillsBack;
    [SerializeField] GameObject[] SkillsTreeBackObjects;
    [SerializeField] GameObject[] UltimatesBack;
    [SerializeField] GameObject[] ChosenSkills;
    [SerializeField] SkillsInfo SkillsInformation;
    [SerializeField] GameObject SkillPointsCount;
    [SerializeField] Player_Info PlayerInformation;
    [SerializeField] UltimatesInfo UltimateInformation;
    
    int currentTree = 0;

    //DESCRIPTION:
    [SerializeField] GameObject Description_Obj;
    [SerializeField] GameObject Description_SkillImage;
    [SerializeField] GameObject Description_SkillName;
    [SerializeField] GameObject Description_SkillDescription;
    [SerializeField] GameObject Description_SkillLevel;
    [SerializeField] GameObject Description_UltimateRequiredSkills;
    [SerializeField] GameObject Description_UltimateRequiredSkillsText;
    [SerializeField] GameObject LearnSkillButton;
    [SerializeField] GameObject AddSkillButton;
    [SerializeField] GameObject RemoveSkillButton;
    [SerializeField] GameObject UpgradeSkillButton;
    


    public void ChangeTree(int tree_id)
    {
        TreeButtons[currentTree].GetComponent<Button>().interactable = true;
        TreeButtons[tree_id].GetComponent<Button>().interactable = false;
        Trees[currentTree].SetActive(false);
        SkillsTreeBackObjects[currentTree].SetActive(false);
        Trees[tree_id].SetActive(true);
        SkillsTreeBackObjects[tree_id].SetActive(true);
        currentTree = tree_id;
    }

    public void CloseTree()
    {
        PlayerInterface.SetActive(true);
        TreeInterface.SetActive(false);
        Description_Obj.SetActive(false);
    }

    public void OpenTree()
    {
        ChangeTree(0);
        SetSkillsImage();
        UpdateSkillsBack();
        UpdateUltimatesBack();
        ChosenSkillsUpdate();
        SetSkillpointsCount();
        PlayerInterface.SetActive(false);
        TreeInterface.SetActive(true);
    }

    public void ShowDescription(int skill_id)
    {
        Description_SkillImage.GetComponent<Image>().sprite = SkillsInformation.SkillSprite[skill_id];
        Description_SkillName.GetComponent<TextMeshProUGUI>().SetText(SkillsInformation.SkillName[skill_id]);
        Description_SkillDescription.GetComponent<TextMeshProUGUI>().SetText(SkillsInformation.SkillDescription[skill_id]);
        Description_SkillLevel.GetComponent<TextMeshProUGUI>().SetText("(" + SkillsInformation.SkillLevel[skill_id] + "/3)");
        Description_UltimateRequiredSkills.SetActive(false);
        Description_UltimateRequiredSkillsText.SetActive(false);
        LearnSkillButton.SetActive(false);
        AddSkillButton.SetActive(false);
        RemoveSkillButton.SetActive(false);
        UpgradeSkillButton.SetActive(false);

        if (SkillsInformation.SkillIsLearned[skill_id] == true)
        {
            if(SkillsInformation.SkillLevel[skill_id]<3 && PlayerInformation.skill_points>0)
            {
                UpgradeSkillButton.SetActive(true);
                UpgradeSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                UpgradeSkillButton.GetComponent<Button>().onClick.AddListener(delegate { UpgradeSkill(skill_id); });
            }

            if (SkillsInformation.SkillIsEquiped[skill_id] == true)
            {
                RemoveSkillButton.SetActive(true);
                RemoveSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                RemoveSkillButton.GetComponent<Button>().onClick.AddListener(delegate { RemoveSkill(skill_id); });
            }
            else
            {
                AddSkillButton.SetActive(true);
                AddSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                AddSkillButton.GetComponent<Button>().onClick.AddListener(delegate { AddSkill(skill_id); });
            }
        }
        else
        {
            if(PlayerInformation.skill_points>0 && SkillCanBeLearned(skill_id)==true)
            {
                LearnSkillButton.SetActive(true);
                LearnSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                LearnSkillButton.GetComponent<Button>().onClick.AddListener(delegate { LearnSkill(skill_id); });
            }
        }

        Description_Obj.SetActive(true);
    }
    public void UpdateSkillsBack()
    {
        for(int i=0;i<Skills.Length;i++)
        {
            SkillsBack[i].GetComponent<Image>().color = new Color32(133, 133, 133, 255);
            if(SkillsInformation.SkillIsLearned[i]==true)
            {
                SkillsBack[i].GetComponent<Image>().color = new Color32(5,155,0,255);
            }
            else
            {
                if(SkillCanBeLearned(i) == true)
                {
                    SkillsBack[i].GetComponent<Image>().color = new Color32(217, 0 , 0, 255);
                }
            }
            if(SkillsInformation.SkillIsEquiped[i]==true)
            {
                SkillsBack[i].GetComponent<Image>().color = new Color32(217,174,40,255);
            }


        }
    }

    public void SetSkillsImage()
    {
        for (int i = 0; i < Skills.Length; i++)
        {
            Skills[i].GetComponent<Image>().sprite = SkillsInformation.SkillSprite[i];
        }
    }

    public void SetSkillpointsCount()
    {
        SkillPointsCount.GetComponent<TextMeshProUGUI>().SetText(PlayerInformation.skill_points.ToString());
    }
    public void AddSkill(int skill_id)
    {
        for(int i=0;i<3;i++)
        {
            if(PlayerInformation.Skills_Id[i]==-1)
            {
                PlayerInformation.Skills_Id[i] = skill_id;
                SkillsInformation.SkillIsEquiped[skill_id] = true;
                ChosenSkillsUpdate();
                break;
            }
        }
        UpdateSkillsBack();
        ChosenSkillsUpdate();
        ShowDescription(skill_id);
    }

    public void RemoveSkill(int skill_id)
    {
        for (int i = 0; i < 3; i++)
        {
            if (PlayerInformation.Skills_Id[i] == skill_id)
            {
                PlayerInformation.Skills_Id[i] = -1;
                SkillsInformation.SkillIsEquiped[skill_id] = false;
                ChosenSkillsUpdate();
                break;
            }
        }
        UpdateSkillsBack();
        ChosenSkillsUpdate();
        ShowDescription(skill_id);
    }

    public void LearnSkill(int skill_id)
    {
        SkillsInformation.SkillIsLearned[skill_id] = true;
        UpdateSkillsBack();
        PlayerInformation.skill_points--;
        ShowDescription(skill_id);
        SetSkillpointsCount();
    }

    public void UpgradeSkill(int skill_id)
    {
        SkillsInformation.SkillLevel[skill_id]++;
        PlayerInformation.skill_points--;
        ShowDescription(skill_id);
        SetSkillpointsCount();
    }

    public void AddUltimate(int ulti_id)
    {
        if(PlayerInformation.Ultimate_Id==-1)
        {
            PlayerInformation.Ultimate_Id = ulti_id;
            UltimateInformation.UltimateIsEquiped[ulti_id] = true;
            ChosenSkillsUpdate();
        }
        UpdateUltimatesBack();
        ChosenSkillsUpdate();
        ShowUltimateDescription(ulti_id);
    }

    public void RemoveUltimate(int ulti_id) 
    {
        PlayerInformation.Ultimate_Id = -1;
        UltimateInformation.UltimateIsEquiped[ulti_id] = false;
        ChosenSkillsUpdate();
        UpdateUltimatesBack();
        ShowUltimateDescription(ulti_id);
    }

    public void LearnUltimate(int ulti_id) 
    {
        UltimateInformation.UltimateIsLearned[ulti_id] = true;
        UpdateUltimatesBack();
        PlayerInformation.skill_points--;
        ShowUltimateDescription(ulti_id);
        SetSkillpointsCount();
    }
    
    public void ShowUltimateDescription(int ulti_id)
    {
        Description_SkillImage.GetComponent<Image>().sprite = UltimateInformation.UltimateSprite[ulti_id];
        Description_SkillName.GetComponent<TextMeshProUGUI>().SetText(UltimateInformation.UltimateName[ulti_id]);
        Description_SkillDescription.GetComponent<TextMeshProUGUI>().SetText(UltimateInformation.UltimateDescription[ulti_id]);
        Description_UltimateRequiredSkillsText.GetComponent<TextMeshProUGUI>().SetText(UltimateInformation.UltimateName[UltimateInformation.FirstRequiredSkillID[ulti_id]]+";\r\n" +
                UltimateInformation.UltimateName[UltimateInformation.SecondRequiredSkillID[ulti_id]] + ";\r\n" + UltimateInformation.UltimateName[UltimateInformation.ThirdRequiredSkillID[ulti_id]] + ".");

        Description_UltimateRequiredSkills.SetActive(true);
        Description_UltimateRequiredSkillsText.SetActive(true);
        LearnSkillButton.SetActive(false);
        AddSkillButton.SetActive(false);
        RemoveSkillButton.SetActive(false);
        UpgradeSkillButton.SetActive(false);

        if (UltimateInformation.UltimateIsLearned[ulti_id]==true)
        {
            Description_UltimateRequiredSkills.SetActive(false);
            Description_UltimateRequiredSkillsText.SetActive(false);

            if (UltimateInformation.UltimateIsEquiped[ulti_id] == true)
            {
                RemoveSkillButton.SetActive(true);
                RemoveSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                RemoveSkillButton.GetComponent<Button>().onClick.AddListener(delegate { RemoveUltimate(ulti_id); });
            }
            else
            {
                AddSkillButton.SetActive(true);
                AddSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                AddSkillButton.GetComponent<Button>().onClick.AddListener(delegate { AddUltimate(ulti_id); });
            }
        }
        else
        {
            if(PlayerInformation.skill_points>0 && UltimateCanBeLearned(ulti_id)==true)
            {
                LearnSkillButton.SetActive(true);
                LearnSkillButton.GetComponent<Button>().onClick.RemoveAllListeners();
                LearnSkillButton.GetComponent<Button>().onClick.AddListener(delegate { LearnUltimate(ulti_id); });
            }
        }
        Description_Obj.SetActive(true);
    }

    public void UpdateUltimatesBack() 
    {
        for (int i = 0; i < Ultimates.Length; i++)
        {
            UltimatesBack[i].GetComponent<Image>().color = new Color32(133, 133, 133, 255);
            if (UltimateInformation.UltimateIsLearned[i] == true)
            {
                UltimatesBack[i].GetComponent<Image>().color = new Color32(5, 155, 0, 255);
            }
            else
            {
                if (UltimateCanBeLearned(i) == true)
                {
                    UltimatesBack[i].GetComponent<Image>().color = new Color32(217, 0, 0, 255);
                }
            }
            if (UltimateInformation.UltimateIsEquiped[i] == true)
            {
                UltimatesBack[i].GetComponent<Image>().color = new Color32(217, 174, 40, 255);
            }
        }
    }
    

    public void ChosenSkillsUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            if (PlayerInformation.Skills_Id[i] == -1)
            {
                ChosenSkills[i].GetComponent<Image>().sprite = null;
            }
            else
            {
                ChosenSkills[i].GetComponent<Image>().sprite = SkillsInformation.SkillSprite[PlayerInformation.Skills_Id[i]];
            }
        }

        if (PlayerInformation.Ultimate_Id == -1)
        {
            ChosenSkills[3].GetComponent<Image>().sprite = null;
        }
        else
        {
            ChosenSkills[3].GetComponent<Image>().sprite = UltimateInformation.UltimateSprite[PlayerInformation.Ultimate_Id];

        }
    }

    public bool UltimateCanBeLearned(int ulti_id) // ???
    {
        switch(ulti_id)
        {
            case 1:
                {
                    
                    return true;
                }
            case 2:
                {
                    return false;
                }
            case 3:
                {
                    return false;
                }
            case 4:
                {
                    return false;
                }
            case 5:
                {
                    return false;
                }
        }
        return false;
    }
    public bool SkillCanBeLearned(int skill_id)
    {
        switch(skill_id)
        {
            case 1:
                {
                    if(SkillsInformation.SkillIsLearned[0]==true)
                    {
                        return true;
                    }
                    break;
                }
            case 2:
                {
                    if(SkillsInformation.SkillIsLearned[1]==true)
                    {
                        return true;
                    }
                    break;
                }
            case 3:
                {
                    if(SkillsInformation.SkillIsLearned[2] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 4:
                {

                    if (SkillsInformation.SkillIsLearned[3] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 5:
                {
                    if (SkillsInformation.SkillIsLearned[4] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 6:
                {
                    if (SkillsInformation.SkillIsLearned[4] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 7:
                {
                    if (SkillsInformation.SkillIsLearned[5] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 8:
                {
                    if (SkillsInformation.SkillIsLearned[1] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 9:
                {
                    if (SkillsInformation.SkillIsLearned[8] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 10:
                {
                    if (SkillsInformation.SkillIsLearned[9] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 11:
                {
                    if (SkillsInformation.SkillIsLearned[10] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 12:
                {
                    if (SkillsInformation.SkillIsLearned[11] == true)
                    {
                        return true;
                    }
                    break;
                }
            case 13:
                {
                    if (SkillsInformation.SkillIsLearned[11] == true)
                    {
                        return true;
                    }
                    break;
                }

        }
        return false;
    }
   
}
