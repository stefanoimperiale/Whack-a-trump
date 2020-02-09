using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    Text text;

    void Awake()
    {
        this.text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = "CONGRATULATIONS, YOU SCORED " + ScoreManager.Score + " POINTS";
    }

}
