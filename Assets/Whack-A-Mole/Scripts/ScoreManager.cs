using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    public static int Score
    {
        get { return score; }
        set
        {
            if (value < 0)
                score = 0;
            else score = value;
        } }

    Text text;

    void Awake ()
    {
        this.text = GetComponent <Text> ();
        Score = 0;
    }

    void Update ()
    {
        this.text.text = "Score: " + Score;
    }
}
