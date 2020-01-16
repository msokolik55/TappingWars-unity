using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    public float health = 100f;
    public int money = 0;
    public float damage = 0.5f;

    public Image healthBar;
    public Text numberOfCoins;
    public GameObject AIPrefab;
    public Text nameBar;
    public GameObject lostImage;

    public GameObject playerUnit;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = health / 100f;
        numberOfCoins.text = money.ToString();
        nameBar.text = name;

        playerUnit = GameObject.FindGameObjectWithTag("Player");
        player = playerUnit.GetComponent<Player>();
    }

    public void GetDamageByClick()
    {
        health -= player.damage;
        Debug.Log(player.damage);
        Debug.Log(health);
        healthBar.fillAmount = health / 100f;
    }

    public void GetDamage()
    {
        healthBar.fillAmount = health / 100f;
    }

    private void HealMe()
    {
        money -= Shop.repairCost;
        health += Shop.repairHealth;
        GetDamage();
    }

    private void IncreaseDamage()
    {
        money -= Shop.damageCost;
        damage += Shop.damageIncrease;
    }

    private void CheckHealth()
    {
       if (health <= 0)
        {
            lostImage.SetActive(true);
            enabled = false;
        }

    }

    private void Update()
    {
        CheckHealth(); 
        if (health <= 20f && money >= 10.0f)
        {
            HealMe();
        }
        if (money >= 20)
        {
            IncreaseDamage();
        }
    }

}

