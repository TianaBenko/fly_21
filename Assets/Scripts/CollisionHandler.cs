using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadLevelDelay; // в секундах
    [SerializeField] GameObject explosionFX; // префаб эффекта взрыва


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
        //SendMessage("OnPlayerDearh"); // ишет метод в других компонентах на объекте и вызывает его
        flyMove.OnPlayerDearh();
    }

     void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
