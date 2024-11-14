using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Operator : MonoBehaviour
{
    [SerializeField] GameObject player;
    Transform target;
    float delta = 1; // ��������� ����� �������� �� ��������� � ���������
    Vector3 ofset = new Vector3(-1.5f, 0, 0); // ������ ������ �� ����

    void Start()
    {
        target = player.transform;
        transform.localPosition = player.transform.localPosition + ofset;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.LookAt(target, Vector3.up);
        transform.LookAt(target);
        
        
     

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
