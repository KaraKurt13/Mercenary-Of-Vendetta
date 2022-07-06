using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int level; //Номер локації
    public Values spawn_point; //Данні про точку появи гравця
    public Vector3 position; //Точка появи

    public void LevelChange(int level_num) //Загрузка необхідної сцени
    {
        spawn_point.playerPosition = SetSpawnPoint(level_num); // Зміна позиції гравця відовідно до точки появи
        SceneManager.LoadScene(level_num);//Завантаження сцени
    }

   public Vector3 SetSpawnPoint(int level_num)//Встановлення точки появи, в залежності від номеру сцени
    {
        Vector3 player_pos=new Vector3();
        switch (level_num)
        {
            case 0:
                {
            player_pos = new Vector3(-61,47,0);
                    break;
                }
            case 1:
                {
            player_pos = new Vector3(-456, 84, 0);
                    break;
                }
            case 2:
                {
            player_pos = new Vector3(-149, 95, 0);
                    break;
                }
            case 3:
                {
            player_pos = new Vector3(-90, 47, 0);
                    break;
                }
            case 4:
                {
            player_pos = new Vector3(-90, 47, 0);
                    break;
                }
            case 5:
                {
            player_pos = new Vector3(-89, 47, 0);
                    break;
                }
        }
        return player_pos;
    }

    public void LeaveSublocation(int location_id)
    {
        switch(location_id)
        {
            case 3:
                {
                    
                    SceneManager.LoadScene(0);
                    spawn_point.playerPosition = new Vector3(-740, 63, 0);
                    break;
                }
            case 4:
                {
                    spawn_point.playerPosition = new Vector3(-275,47,0);
                    SceneManager.LoadScene(0);
                    break;
                }
            case 5:
                {
                    spawn_point.playerPosition = new Vector3(-889, 63, 0);
                    SceneManager.LoadScene(0);
                    break;
                }

        }
    }
  
} 