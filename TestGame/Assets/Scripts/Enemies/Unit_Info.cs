using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Unit_Info : ScriptableObject 
{
    public string enemy_name;
    public float enemy_max_hp;
    public float enemy_hp;
    public float enemy_damage;
    public int enemy_id;
    public Sprite enemy_sprite;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void Attack(Player_Info Player)
    {
        Player.hp = Player.hp - enemy_damage;
    }
}
