using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerInterface;


    public void OpenMap()
    {
        PlayerInterface.SetActive(false);
        this.gameObject.SetActive(true);
    }
    public void CloseMap()
    {
        PlayerInterface.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
