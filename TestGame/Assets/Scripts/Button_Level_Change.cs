using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Level_Change : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject Level_Button;
    private BoxCollider2D object_box;
    private BoxCollider2D player_box;
    void Start()
    {
        player_box = player.GetComponent<BoxCollider2D>();
        object_box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Level_Button.SetActive(false);
        if (player_box.IsTouching(object_box))
        {
            Level_Button.SetActive(true);
        }
    }
}
