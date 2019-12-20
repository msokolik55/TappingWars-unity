using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Items : NetworkBehaviour
{
    Player playerScript;
    GameObject playerUnit;

    private bool found = false;

    // Start is called before the first frame update
    void FindLocalPlayer()
    {
        //if (NetworkServer.connections.Count > 0)
        //{
            playerUnit = ClientScene.localPlayers[0].gameObject;
            playerScript = playerUnit.GetComponent<Player>();
       // }
    }


    // Update is called once per frame
    void Update()
    {
        if ((NetworkServer.connections.Count > 0) && (found = false))
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
