using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove
    : MonoBehaviour
{
    public int status = 1;
    //[SerializeField] Rigidbody rigidBody; //��� velocity ����� ��������� rigidbody � ���� ������� �������� � ���������, �� ��������� Collision Detection - Continuous Dynamic
    //��� ���� ������. ����� Rigidbody ��������� � ����� �����, � �� �������� ���

    [SerializeField] GameObject[] guns;

    [Header("Move")]
    
    [SerializeField] float angle = -23f;
    [SerializeField] float Speed = 2f;
    [SerializeField] float XClamp = 1.5f;
    [SerializeField] float YClamp = 0.8f;

    [SerializeField] float xRotFactor = -40f;
    [SerializeField] float yRotFactor = 20f;
    //[SerializeField] float zRotFactor = 20f;

    [SerializeField] float xMoveRot = 0f;
    [SerializeField] float yMoveRot = 0f;
    [SerializeField] float zMoveRot = 0f;

    bool isControlEnabled = true;

    float xMove, yMove;

    RotateFly rot;

    public int reversSratus = 1; //  ��������� ����������� ��� ��������������� ���� - �������� -1 ���� isBarrelRoll = false
    void Start()
    {
        rot = FindObjectOfType<RotateFly>();
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().Play();
        }
        CangeRate();
        status = 1;
        Debug.Log(status);

    }


    void Update()
    {
        if (isControlEnabled)
        {
            MoveFly();
            rot.RotFly(xMove, yMove);
            if (status == 1)
            {
                FireGubs();
            }
            if (status == 2)
            {
                FirePistolet();
            }
            if (status == 3)
            {
                FireGubs();
            }
            
        }

    }

    public void OnPlayerDearh()
    {
        // ��������� ���������� ��� ������
        isControlEnabled = false;

    }

    void MoveFly()
    {
        xMove = Input.GetAxis("Horizontal"); // �������� �� ������
        //Debug.Log(xMove);
        yMove = Input.GetAxis("Vertical");
        //Debug.Log(yMove);

        // ������� �� -1 ���� isBarrelRoll = false

        float xOffset = xMove * Speed * Time.deltaTime * reversSratus;
        float yOffset = yMove * Speed * Time.deltaTime * reversSratus;

        float newXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newXPos, -XClamp, XClamp);

        float newYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newYPos, -YClamp, YClamp);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
        //rigidBody.MovePosition(rigidBody.position + new Vector3(clampXPos, clampYPos, transform.localPosition.z));//����� ������ �������� �������� ����
        
    }

    void RotateFly()
    {
        float xRot = angle + transform.localPosition.y * xRotFactor + yMove * xMoveRot;
        float yRot = transform.localPosition.x * yRotFactor + xMove * yMoveRot;
        float zRot = xMove * zMoveRot;

        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    void FireGubs()
    {
        if (Input.GetButtonDown("Fire"))
        {
            ActiveGuns();
            //print(guns.Length);
        }
        if (Input.GetButtonUp("Fire"))
        {
            DeactiveGuns();
        }
    }

    void ActiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }

    void DeactiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }

    void FirePistolet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject gun in guns)
            {
                gun.GetComponent<ParticleSystem>().Emit(1);
            }
        }
    }

    void CangeRate()
    {
        foreach (GameObject gun in guns)
        { 
            var emissionModule = gun.GetComponent<ParticleSystem>().emission; 
            emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(10F);
        }

    }
}
