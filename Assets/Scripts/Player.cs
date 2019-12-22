using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float health = 100f;
    string name;
    int money = 0;
    float damage = 1f;

    public Image healthBar;
    public Text numberOfCoins;
    public GameObject playerPrefab;

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
        if ((money >= 10) && (health < 100))
        {
            if (health + 10f > 100)
            {
                health = 100f;
            }
            else
            {
                health += 10f;
            }
            healthBar.fillAmount = health / 100f;
            money -= 10;
            numberOfCoins.text = money.ToString();
        }
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
    /*
    public void Start()
    {   
        CmdSpawnMyUnit();
    }

    void CmdSpawnMyUnit()
    {
        // Spawn Local Player always on the same position
        playerPrefab.transform.position = new Vector3(-20, -120, 0);
        Instantiate(playerPrefab);
        playerPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }*/
}
