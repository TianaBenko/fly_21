using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionSpiderFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreToAdd = 10;
    [SerializeField] int hits = 10; //количество попаданий до уничтожения
   

    Score scoreBoard; // для обновления счета на экране

    private void Start()
    {
        scoreBoard = FindObjectOfType<Score>();
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scoreToAdd);
        hits--;
        
        if (hits <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        
        GameObject fx = Instantiate(explosionSpiderFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
