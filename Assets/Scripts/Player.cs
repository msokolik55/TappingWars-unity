using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player
{
    float health;
    string name;
    int money;
    float damage;

    public Player(float _health, string _name, int _money, float _damage)
    {
        health = _health;
        name = _name;
        money = _money;
        damage = _damage;
    }

}
