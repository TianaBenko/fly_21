using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OperatorCircle : MonoBehaviour
{
    float rotCamera = 0f;
    float slowRotCamera = 0f;
    float slowRot = 100f;
    float clampSlowRotCamera = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotCamera = Input.GetAxisRaw("Mouse X"); //��������� ����������
        slowRotCamera = slowRotCamera + rotCamera; // �� ��� ���� �������� � �������
        clampSlowRotCamera = Mathf.Clamp(slowRotCamera, -30f, 30f); // ����������� �����
        Debug.Log(slowRotCamera);
        transform.localRotation = Quaternion.Euler(0, clampSlowRotCamera, 0); // ������ ����
    }
}
