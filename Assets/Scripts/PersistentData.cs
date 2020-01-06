using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData PD; //Singleton
    public bool[] allSkins; //One bool for each unlockable skin. Data to save and get from the Playfab cloud
    public int mySkin; //The currently selected skin

    private void OnEnable()
    {
        if (PD == null)
        {
            PD = this;
        }
        else
        {
            if (PD != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    
    //Converts the string from the data pulled from the cloud into the all skins array
    public void SkinsStringToData(string skinsIn)
    {
        for (int i = 0; i < skinsIn.Length; i++)
        {
            if (int.Parse(skinsIn[i].ToString()) > 0)
            {
                allSkins[i] = true;
            }
            else
            {
                allSkins[i] = false;
            }
        }
        MenuController.MC.SetUpStore();
    }
    
    //Converts the all skins array into a string that can then be save to the cloud
    public string SkinsDataToString()
    {
        string toString = "";
        for (int i = 0; i < allSkins.Length; i++)
        {
            if (allSkins[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }

}
