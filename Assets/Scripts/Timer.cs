using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    public Text textBox;

    public static bool timeOver = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = startTime.ToString("f2");

    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        textBox.text = (startTime/60f).ToString("f2");
    }
}
