using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    float health = 100f;
    int money = 0;
    float damage = 1.0f;

    public Image healthBar;
    public Text numberOfCoins;
    public GameObject AIPrefab;
    public Text nameBar;
    public GameObject lostImage;

    public GameObject playerUnit;
    private Player player;

    private IEnumerator enumerator;

    //public GameObject enemy;
    public AI enemy_bot;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = health / 100f;
        numberOfCoins.text = money.ToString();
        nameBar.text = name;

        playerUnit = GameObject.FindGameObjectWithTag("Player");
        player = playerUnit.GetComponent<Player>();

        enumerator = WaitAndPrint(0.2f);
        StartCoroutine(enumerator);
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

    private void CheckHealth()
    {
        if (health <= 0)
        {
            lostImage.SetActive(true);
            StopAllCoroutines();
            enabled = false;
        }
    }

    public void Click()
    {
        if (playerUnit.GetComponent<AI>() == null) //enemy
        {
            player.health -= damage;
            player.GetDamage();
            //Debug.Log("Ja " + gameObject.name + " Utocim na playera");
        }
        else
        {
            enemy_bot.health -= damage;
            enemy_bot.GetDamage();

            //Debug.Log("Ja " + gameObject.name + " Utocim na " + enemy_bot.name);
        }    
    }

    private void Update()
    {
        CheckHealth();        
    }

    // every 0.2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Click();
        }
    }
}

