using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0; // общий счет
    TextMeshProUGUI scoreText;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString(); // выводим общий счет на экран
    }

    // тут будеи прибавлять к общему счету
    public void ScoreHit( int scorePerHit) // количество очков за унмчтожение
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();  // выводим общий счет на экран
    }
}
