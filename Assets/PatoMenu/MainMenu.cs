using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject profile;

    public void Quit()
    {
        Application.Quit();
    }

    public void Profile()
    {
        profile.GetComponent<Animator>().SetBool("open", !profile.GetComponent<Animator>().GetBool("open"));
    }
}
