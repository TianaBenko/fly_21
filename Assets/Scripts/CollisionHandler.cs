using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadLevelDelay; // � ��������
    [SerializeField] GameObject explosionFX; // ������ ������� ������


    FlyMove flyMove;

    void Start()
    {
        
        flyMove = FindAnyObjectByType<FlyMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Hit Trigger");
        StartDeath();
        explosionFX.SetActive(true);
        Invoke("RestartLevel", LoadLevelDelay);
    }

    void StartDeath()
    {
        //SendMessage("OnPlayerDearh"); // ���� ����� � ������ ����������� �� ������� � �������� ���
        flyMove.OnPlayerDearh();
    }

     void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
