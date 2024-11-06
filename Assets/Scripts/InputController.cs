using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]  RotateFly rotateFly;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // если нажата кнопка  "f" то angl плавно меняется от 0 до 360
        {
            if (rotateFly.isSomersaultFinish == false)
            {
                rotateFly.isSomersaultFinish = true;
                rotateFly.angleX = 0f;
            }

        }

        if (Input.GetKeyDown(KeyCode.E)) // если нажата кнопка  "e" то angl плавно меняется от 0 до 180
        {
            if (rotateFly.isBarrelRollFinish == false)
            {
                rotateFly.isBarrelRollFinish = true;
                rotateFly.angleZ = 0f;
            }

        }
    }
}
