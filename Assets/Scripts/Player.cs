using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;
    string name;
    int money = 0;
    public float damage;

    public Image healthBar;
    public Text numberOfCoins;
    public GameObject playerPrefab;

    public GameObject lostImage;

    private void Awake()
    {
        damage = 0.5f;
        money = 0;
        health = 100.0f;
    }

    private void Start()
    {
        healthBar.fillAmount = health / 100f;
        numberOfCoins.text = money.ToString();
    }

    public void EarnMoney()
    {
        money += Shop.earnAmount;
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
                health += Shop.repairHealth;
            }
            healthBar.fillAmount = health / 100f;
            money -= Shop.repairCost;
            numberOfCoins.text = money.ToString();
        }
    }

    public void IncreaseDamage()
    {
        if(money >= 20)
        {
            money -= Shop.damageCost;
            numberOfCoins.text = money.ToString();
            damage += Shop.damageIncrease;
        }
        else
        {
            Debug.Log("Malo penazi");
        }
    }

    public void GetDamage()
    {
        healthBar.fillAmount = health / 100f;
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            lostImage.SetActive(true);
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        CheckHealth();
    }
}
