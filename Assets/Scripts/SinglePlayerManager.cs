using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManager : MonoBehaviour
{
    //public List<GameObject> players = new List<GameObject>();
    public List<Text> names = new List<Text>();

    private int difficulty = 2;
    private int nameAI = 1;
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text name in names)
        {
            name.text = AInames(difficulty) + nameAI.ToString();
            nameAI += 1;
        }
    }

    private string AInames(int _difficulty)
    {
        switch (_difficulty) {
            case 1:
                return "Easy";
            case 2:
                return "Normal";
            case 3:
                return "Hard";
            default:
                return "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
