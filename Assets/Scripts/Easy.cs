using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Easy : MonoBehaviour
{
    public GameObject[] units;
    private GameObject myUnit;
    private List<GameObject> players = new List<GameObject>();

    private GameObject enemy;

    public Player player = null;
    public AI enemyBot = null;

    AI AIscript;
    private int changeEnemy = 0;
    private bool attack = false;
    private bool earn = true;

    // Start is called before the first frame update
    void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject unit in units)
        {
            if (unit == this.gameObject)
            {
                continue;
            }
            else
            {
                players.Add(unit);
            }
        }
        StartCoroutine(enumerator(0.2f));
        ChooseTarget();
        AIscript = gameObject.GetComponent<AI>();
    }

    private void CheckIfSomeoneLost()
    {
        GameObject lostImage;

        foreach (GameObject _player in players)
        {
            lostImage = _player.transform.FindChild("Lost").gameObject;
            if (lostImage.activeSelf)
            {
                players.Remove(_player);
                Debug.Log(_player.name);
            }
        }
    }
    
    private void CheckHealth()
    {
       if((AIscript.health <= 20f) && earn == false)
        {
            earn = true;
            attack = false;
            player = null;
            enemyBot = null;
        }
       else if (AIscript.health > 20f && earn == true)
        {
            attack = !attack;
            earn = !earn;
            ChooseTarget();
        }
    }

    private void Attack()
    {
        if (player == null)
        {
            enemyBot.health -= AIscript.damage;
            enemyBot.GetDamage();
        }
        else if (enemyBot == null)
        {
            player.health -= AIscript.damage;
            player.GetDamage();
        }
    }

    private void EarnMoney()
    {
        AIscript.money += Shop.earnAmount;
    }

    private IEnumerator enumerator(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (attack)
            {
                Attack();
                changeEnemy += 1;
            }
            else
            {
                EarnMoney();
            }

            if (changeEnemy == 5)
            {
                ChooseTarget();
            }
        }
    }

    private void ChooseTarget()
    {
        changeEnemy = 0;

        enemy = players[Random.Range(0, players.Count)];
        if (enemy.GetComponent<AI>() == null) //enemy
        {
            player = enemy.GetComponent<Player>();
            enemyBot = null;
        }
        else
        {
            enemyBot = enemy.GetComponent<AI>();
            player = null;
        }
    }

    private void FixedUpdate()
    {
        CheckIfSomeoneLost();
        CheckHealth();
    }
}
