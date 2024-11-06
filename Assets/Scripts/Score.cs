using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0; // ����� ����
    TextMeshProUGUI scoreText;
    
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString(); // ������� ����� ���� �� �����
    }

    // ��� ����� ���������� � ������ �����
    public void ScoreHit( int scorePerHit) // ���������� ����� �� �����������
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();  // ������� ����� ���� �� �����
    }
}
