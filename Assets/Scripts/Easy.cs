using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Easy : MonoBehaviour
{
    private GameObject[] units;
    private GameObject myUnit;
    private List<GameObject> players = new List<GameObject>();

    private GameObject enemy;

    AI AIscript;
    private IEnumerator enumurator;

    // Start is called before the first frame update
    void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject unit in units)
        {
            if (unit == this.gameObject)
            {
                myUnit = unit;
            }
            else
            {
                players.Add(unit);
            }
        }

        AIscript = gameObject.GetComponent<AI>();
        StartCoroutine(enumerator(2f));
    }
    /*
    private bool CanDefeated()
    {
        return true;
    }*/

    private void CheckIfSomeoneLost()
    {
        GameObject lostImage;

        foreach(GameObject player in players)
        {
            lostImage = player.transform.FindChild("Lost").gameObject;
            if (lostImage.activeSelf)
            {
                players.Remove(player);
                Debug.Log(player.name);
                ChooseTarget();
            }
        }
    }
    
    private IEnumerator enumerator(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ChooseTarget();
        }
    }

    private void ChooseTarget()
    {
        enemy = players[Random.Range(0, players.Count)];
        AIscript.playerUnit = enemy;
        if (enemy.GetComponent<AI>() != null)
        {
            AIscript.enemy_bot = enemy.GetComponent<AI>();
        }
    }

    private void Update()
    {
        CheckIfSomeoneLost();
    }
}
