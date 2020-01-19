using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleplayer : MonoBehaviour
{
    public Text title;
    public Text skin;

    // Start is called before the first frame update
    void Start()
    {
        title.text = SetDifficulty.Difficulty.ToString();
        skin.text = PersistentData.PD.mySkin.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
