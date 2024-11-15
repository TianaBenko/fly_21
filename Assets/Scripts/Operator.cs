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
        rotateCamera = Input.GetAxisRaw("Mouse X"); //��������� ����������
        slowRotateCamera = transform.localPosition.x + rotateCamera * slow * -1; // �� ��� ���� �������� � �������
        clampSlowrotateCamera = Mathf.Clamp(slowRotateCamera, -5f, 5f);// ����������� ���������
        transform.localPosition = new Vector3(clampSlowrotateCamera, 0, transform.localPosition.z);// ������ ���������


        



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
