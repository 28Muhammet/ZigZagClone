using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
