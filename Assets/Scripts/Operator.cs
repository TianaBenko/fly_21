using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject player;
    Transform target;
    float delta = 1; // уменьшает време перехода из положения в положение
    Vector3 ofset = new Vector3(-1.5f, 0, 0); // отступ камеры от мухи
    float rotateCamera = 0f;
    float slowRotateCamera = 0f;
    float slow = 0.1f;
    float clampSlowrotateCamera = 0f;



    void Start()
    {
        target = player.transform;
        //transform.localPosition = player.transform.localPosition + ofset;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.LookAt(target, Vector3.up);
        transform.LookAt(target);
        rotateCamera = Input.GetAxisRaw("Mouse X"); //маленькое отклонение
        slowRotateCamera = transform.localPosition.x + rotateCamera * slow * -1; // то что надо передать в позицию
        clampSlowrotateCamera = Mathf.Clamp(slowRotateCamera, -5f, 5f);// ограничение растояния
        transform.localPosition = new Vector3(clampSlowrotateCamera, 0, transform.localPosition.z);// меняем пастояние


        



    }

    private void LateUpdate()
    {
        
        //transform.localPosition = player.transform.localPosition + ofset;
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + ofset, delta * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }
}
