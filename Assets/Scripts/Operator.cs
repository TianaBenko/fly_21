using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject player;
    Transform target;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        //transform.LookAt(target, Vector3.up);

        
        
     

    }

    private void LateUpdate()
    {
        transform.LookAt(target);
        //transform.position = player.transform.position + new Vector3 (-1.5f, 0, 0);
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(-1.5f, 0 , 0), Time.deltaTime);
    }  
}
