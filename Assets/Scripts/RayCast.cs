using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCastInformation();
    }

    private void RayCastInformation()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) 
        {
            //Debug.Log(hit.transform.name + hit.transform.position);
            point.position = hit.point;
        }
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
