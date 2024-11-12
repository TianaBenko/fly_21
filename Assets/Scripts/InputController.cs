using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class InputController : MonoBehaviour
{
    [SerializeField]  RotateFly rotateFly;
    [SerializeField] PathFollower pathFollower;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // ���� ������ ������  "f" �� angl ������ �������� �� 0 �� 360
        {
            if (rotateFly.isSomersaultFinish == false)
            {
                rotateFly.isSomersaultFinish = true;
                rotateFly.angleX = 0f;
            }

        }

        if (Input.GetKeyDown(KeyCode.E)) // ���� ������ ������  "e" �� angl ������ �������� �� 0 �� 180
        {
            if (rotateFly.isBarrelRollFinish == false)
            {
                rotateFly.isBarrelRollFinish = true;
                rotateFly.angleZ = 0f;
            }

        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (pathFollower.speed == 6f)
            {
                pathFollower.speed = 30f;
            }
            else
            {
                pathFollower.speed = 6f;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        
    }
}
