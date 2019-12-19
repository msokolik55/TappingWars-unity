using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Player playerScript;
    public GameObject playerUnit;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerUnit.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepairTool()
    {
        playerScript.Repair();
    }

    public void DamageTool()
    {
        playerScript.IncreaseDamage();
    }
}
