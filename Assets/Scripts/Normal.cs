using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Normal : MonoBehaviour
{
    public GameObject[] units;
    private GameObject myUnit;
    private List<GameObject> players = new List<GameObject>();

    private GameObject enemy;

    public Player playerObj = null;
    public AI botEnemy = null;

    private AI AIscript;
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
        ChooseTargetRandomly();
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
        if ((AIscript.health <= 20f) && earn == false)
        {
            earn = !earn;
            attack = !attack;
            playerObj = null;
            botEnemy = null;
        }
        else if ((AIscript.health > 20f) && earn == true)
        {
            attack = !attack;
            earn = !earn;
            ChooseTarget();
        }
    }

    private void Attack()
    {
        if (playerObj == null)
        {
            botEnemy.health -= AIscript.damage;
            botEnemy.GetDamage();
        }
        else if (botEnemy == null)
        {
            playerObj.health -= AIscript.damage;
            playerObj.GetDamage();
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
                if (AIscript.health < 30f){
                    ChooseTarget();
                }
                else
                {
                    ChooseTargetRandomly();
                }
            }
        }
    }

    private void ChooseTargetRandomly()
    {
        changeEnemy = 0;

        enemy = players[Random.Range(0, players.Count)];
        if (enemy.GetComponent<AI>() == null) //enemy
        {
            playerObj = enemy.GetComponent<Player>();
            botEnemy = null;
        }
        else
        {
            botEnemy = enemy.GetComponent<AI>();
            playerObj = null;
        }
    }

    private void ChooseTarget()
    {
        changeEnemy = 0;
        float lowestHealth = 0.0f;

        if (players[0].GetComponent<AI>() == null)
        {
            playerObj = players[0].GetComponent<Player>();
            lowestHealth = playerObj.health;
            botEnemy = null;
        }
        else
        {
            botEnemy = players[0].GetComponent<AI>();
            lowestHealth = botEnemy.health;
            playerObj = null;
        }

        enemy = players[0];

        foreach (GameObject player in players)
        {
            if (player.GetComponent<AI>() == null)
            {
                if (player.GetComponent<Player>().health < lowestHealth)
                {
                    playerObj = player.GetComponent<Player>();
                    lowestHealth = playerObj.health;
                    botEnemy = null;
                }
            }
            else
            {
                if (player.GetComponent<AI>().health < lowestHealth)
                {
                    botEnemy = player.GetComponent<AI>();
                    lowestHealth = botEnemy.health;
                    playerObj = null;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        CheckIfSomeoneLost();
        CheckHealth();
    }
}
