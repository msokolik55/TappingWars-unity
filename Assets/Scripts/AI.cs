using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    float health = 100f;
    int money = 0;
    float damage = 1f;

    public Image healthBar;
    public Text numberOfCoins;
    public GameObject AIPrefab;
    public Text nameBar;
    public GameObject lostImage;

    private GameObject playerUnit;
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

    public void GetDamage()
    {
        health -= player.damage;
        Debug.Log(player.damage);
        Debug.Log(health);
        healthBar.fillAmount = health / 100f;
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            lostImage.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        CheckHealth();
    }
}
