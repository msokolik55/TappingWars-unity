using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    float health = 100f;
    string name;
    int money = 0;
    float damage = 1f;

    public Image healthBar;
    public Text numberOfCoins;


    public Player(float _health, string _name, int _money, float _damage)
    {
        health = _health;
        name = _name;
        money = _money;
        damage = _damage;

        healthBar.fillAmount = health / 100f;    // priradit to funkcie takeDamage
    }

    public void TakeDamage()
    {
        healthBar.fillAmount = health / 100f;
    }

    public void EarnMoney()
    {
        money += 5;
        numberOfCoins.text = money.ToString();
    }

    public void Repair()
    {
        if (health + 10f > 100)
        {
            health = 100f;
        }else
        {
            health += 10f;
        }
        healthBar.fillAmount = health / 100f; 
    }

    public void IncreaseDamage()
    {
        if(money >= 20)
        {
            money -= 20;
            numberOfCoins.text = money.ToString(); 
        }
        else
        {
            // vypisat ze ma malo penazi
        }
    }

}
