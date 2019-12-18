using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Player : MonoBehaviour
{
    float health = 100f;
    string name;
    int money = 0;
    float damage = 1f;

    public Image healthBar; 
    

    public Player(float _health, string _name, int _money, float _damage)
    {
        health = _health;
        name = _name;
        money = _money;
        damage = _damage;

        healthBar.fillAmount = health / 100f;    // priradit to funkcie takeDamage
    }

}
