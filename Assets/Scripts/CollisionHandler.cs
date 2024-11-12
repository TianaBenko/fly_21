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
        if(other.tag == "wall")
        {
            
            StartDeath();
            explosionFX.SetActive(true);
            Invoke("RestartLevel", LoadLevelDelay);
        }
        if(other.tag == "gologramm")
        {
            //Debug.Log("Hit Trigger");
            flyMove.status = 2;
            //Debug.Log(flyMove.status);
        }
        
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
