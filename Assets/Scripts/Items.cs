using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Player playerScript;
    GameObject playerUnit;

    private bool found = false;

    // Start is called before the first frame update
    void FindLocalPlayer()
    {
        playerUnit = GameObject.Find("Player");
        playerScript = playerUnit.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (found == false)
        {
            FindLocalPlayer();
            found = true;
        }
    }

    public void RepairTool()
    {
        FindLocalPlayer();
        playerScript.Repair();
    }

    public void DamageTool()
    {
        playerScript.IncreaseDamage();
    }
}
