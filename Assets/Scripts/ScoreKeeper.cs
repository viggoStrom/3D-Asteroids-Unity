using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    public void UpdateScore()
    {
        Score += 1;
        PlayerPrefs.SetInt("Score", Score);
        ScoreText.text = "Score: " + Score;
    }
}
