using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    public enum Difficulties { easy, medium, hard };

    public static Difficulties Difficulty = Difficulties.easy;

    public void SetEasyDifficulty()
    {
        Difficulty = Difficulties.easy;
    }

    public void SetMediumDifficulty()
    {
        Difficulty = Difficulties.medium;
    }

    public void SetHardDifficulty()
    {
        Difficulty = Difficulties.hard;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
