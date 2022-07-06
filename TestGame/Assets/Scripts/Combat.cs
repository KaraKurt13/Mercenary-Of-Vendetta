using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Combat : MonoBehaviour
{
    
    [SerializeField] public Image bar;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject End_Battle_Button;
    [SerializeField] public GameObject Attack_Button;
    [SerializeField] public Unit_Info[] Enemies_Info;
    [SerializeField] public Image[] Enemies_Bars;
    [SerializeField] public GameObject[] Enemies_Objects;
    [SerializeField] public GameObject[] Enemies_Buttons;

    [SerializeField] public FightSettings SetSettings;
    public Values spawn_point;

    public Player_Info player_i;
    private int count_max=4;
    private int count = 0;
    public float[] max_hp;
    public float[] hp;
    public float[] damage;
    public int[] id;
    public float fill;
    public int click=0;


    void Start()
    {
        for (int i=0;i<Enemies_Info.Length;i++)
        {
            max_hp[i] = Enemies_Info[i].enemy_max_hp;
            hp[i] = Enemies_Info[i].enemy_hp;
            damage[i] = Enemies_Info[i].enemy_damage;
            id[i] = Enemies_Info[i].enemy_id;
        }
        fill = 1f;
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        switch (click)
        {
            case 0:
                {
                    for(int i=0;i<Enemies_Buttons.Length;i++)
                    {
                        if (Enemies_Objects[i].activeSelf == false) { continue; }
                        Enemies_Buttons[i].SetActive(true);
                    }
                    click = 1;
                    break;
                }
            case 1:
                {

                    for (int i = 0; i < Enemies_Buttons.Length; i++)
                    {
                        Enemies_Buttons[i].SetActive(false);
                    }
                    click = 0;
                    break;
                }

        }
    }
    
    public void Fight(int i) //Удар по ворогу
    { 
            hp[i] = hp[i] - player_i.damage; //Зменшується рівень здоров'я в залежності від шкоди персонажа
        Enemies_Bars[i].fillAmount = hp[i] / max_hp[i]; // Оновлюється стрічка здоров'я
            if (hp[i] <= 0) //Якщо рівень HP меньше дорівнює 0
            {
                if (Enemies_Objects[i].activeSelf == true) // Якщо ворог з ID 'i' був живий
                {
                    count++; // Збільшується лічильник вбитих ворогів
                }
                Enemies_Objects[i].SetActive(false); //Деактивовується об'єкт ворога
            Enemies_Buttons[i].SetActive(false); //Деактивовується кнопка атаки по ворогу
            }
        if (count == count_max) //Якщо вбиті усі вороги
        {
            Attack_Button.SetActive(false); //Відключається кнопка атаки
            End_Battle_Button.SetActive(true); // Активовується кнопка виходу з битви
        }
        EnemyTurn(); //Якщо ще є живі вороги, то здійснюється хід ворога
        bar.fillAmount = player_i.hp / 300; 
    }

    void EnemyTurn()
    {
        for(int i=0;i<Enemies_Info.Length;i++)
        {
            if (Enemies_Objects[i].activeSelf == true) { player_i.hp = Enemy_AI(id[i], max_hp[i], hp[i], damage[i], player_i.hp, player_i.damage); }
        }
    }



    public float Enemy_AI(int enemy_id, float enemy_max_hp, float enemy_hp, float enemy_damage, float player_hp, float player_damage)
    {
        switch (enemy_id)
        {
            case 0:
                {
                    player_hp=Attack(enemy_damage, player_hp);
                    Debug.Log("ENEMY_AI - " + player_hp);
                    break;

                }
            case 1:
                {

                    player_hp=Attack(enemy_damage, player_hp);
                    Debug.Log(player_hp);
                    break;
                }
        }
        return player_hp;
    }

    public float Attack(float e_damage, float p_hp)
    {
        Debug.Log(p_hp);
        Debug.Log(e_damage);
        p_hp = p_hp - e_damage;
        Debug.Log(p_hp);
        return p_hp;
    }
    
    public void EndFight()
    {
        SceneManager.LoadScene(SetSettings.scene_id);
        spawn_point.playerPosition = SetSettings.player_pos;
        SetSettings.FightLocation.FightIsCompleted[SetSettings.fight_id] = true;
    }
}
