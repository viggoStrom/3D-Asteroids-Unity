using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
        ScoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
