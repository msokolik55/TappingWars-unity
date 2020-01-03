using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    public Text textBox;

    private string seconds;
    private string minutes;
    private int time = 120;

    public static bool timeOver = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = startTime.ToString("f2");

    }

    private void DisplayTime()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (time == 0)
        {
            timeOver = true;
        }
        else
        {
            startTime += Time.deltaTime;
            time = 120 - ((int) Mathf.Round(startTime * 100) / 100);
            minutes = "0" + (time / 60).ToString();
            seconds = ((time % 60) < 10) ? "0"+(time % 60).ToString() : (time % 60).ToString();

            textBox.text = minutes + ":" + seconds;
        }
    }
}
