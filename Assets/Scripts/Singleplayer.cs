using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleplayer : MonoBehaviour
{
    public Text title;

    // Start is called before the first frame update
    void Start()
    {
        title.text = SetDifficulty.Difficulty.ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
