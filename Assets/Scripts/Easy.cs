using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour
{
    private GameObject[] units;
    private GameObject myUnit;
    private List<GameObject> players = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject unit in units)
        {
            if (unit == this.gameObject)
            {
                //Debug.Log(unit.name);
                myUnit = unit;
            }
            else
            {
                players.Add(unit);
            }
        }
    }

    private bool CanDefeated()
    {



        return true;
    }

    private void FixedUpdate()
    {
        
    }
}
