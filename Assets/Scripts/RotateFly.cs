using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RotateFly : MonoBehaviour
{


    [SerializeField] float speedSomersault = 100f;
    [SerializeField] float speedBarrelRoll = 100f;

    public float angleX = 361f;
    public float angleZ = 361f;

    [SerializeField] float xRotFactor = -40f;
    [SerializeField] float yRotFactor = 20f;

    [SerializeField] float xMoveRot = -40f;
    [SerializeField] float yMoveRot = 30f;
    [SerializeField] float zMoveRot = 30f;

    public bool isSomersaultFinish = false;
    public bool isBarrelRollFinish = false; 
    private bool oneDo = true; // ��� ���������� ���� ���
    private bool isBarrelRoll = true; // ����� �� �������

    FlyMove move;

    private void Start()
    {
        move = FindObjectOfType<FlyMove>();
    }

    private void Update()
    {
        if (angleX < 360f)
        {
            Somersault();
        }
        else
        {
            isSomersaultFinish = false;
        }

        if (angleZ < 360f)
        {
            if (isBarrelRoll)
            {
                DoBarrelRoll();
            }
            if (angleZ >= 180f && oneDo)
            {
                isBarrelRoll = false;
                oneDo = false;
                move.reversSratus = -1;
                Invoke("DoBarrelRollInvoke", 2f);
            }

        }
        else 
        {
            oneDo = true;
            isBarrelRollFinish = false;
        }

        // ��� ���������������� �������? ����� ����������, ������� ����� ��������, ��� ������ z ���� �������������, � ��� ����� 180, �� z ���� ���������



    }


    public void RotFly(float xMove, float yMove)
    {
        float xRot = angleX + transform.localPosition.y * xRotFactor + yMove * xMoveRot;
        float yRot = transform.localPosition.x * yRotFactor + xMove * yMoveRot;
        float zRot = angleZ + xMove * zMoveRot;

        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);

    } 

    private void Somersault () //  ����� ������� ����� ������������ ��� ������������ 
    {
        angleX = angleX + (speedSomersault * Time.deltaTime);
    }

    private void DoBarrelRoll()
    {
        angleZ = angleZ + (speedSomersault * Time.deltaTime);

        Debug.Log(angleZ);
        
        //yield return new WaitForSeconds(2f);
        //angleZ = angleZ + (speedSomersault * Time.deltaTime);// �� 360
    }

    private void DoBarrelRollInvoke()
    {
        Debug.Log("����" + angleZ);
        //angleZ = 184f;
        isBarrelRoll = true;
        move.reversSratus = 1;
    }

}
