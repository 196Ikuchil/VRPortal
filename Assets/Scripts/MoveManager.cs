using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    [SerializeField]
    HeadCameraScript mainCamera;
    [SerializeField]
    HeadCameraScript subCamera;

    float _speed = 0.05f;


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward(mainCamera);
            MoveForward(subCamera);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveBack(mainCamera);
            MoveBack(subCamera);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight(mainCamera);
            MoveRight(subCamera);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(mainCamera);
            MoveLeft(subCamera);
        }
    }

    #region KeyBoardMove
    Vector3 vectVer;
    Vector3 vectHori;
    [SerializeField]
    float moveSpeed = 10;
    public void MoveForward(HeadCameraScript camera)
    {
        vectVer =  camera.GetCameraForward().normalized * Time.deltaTime * moveSpeed;
        vectVer.y = 0;
        camera.movePosition(vectVer);
    }

    public void MoveRight(HeadCameraScript camera)
    {
        vectHori = camera.GetCameraRight().normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        camera.movePosition(vectHori);
    }

    public void MoveLeft(HeadCameraScript camera)
    {
        vectHori = camera.GetCameraRight().normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        camera.movePosition(-vectHori);
    }

    public void MoveBack(HeadCameraScript camera) 
    {
        vectVer = camera.GetCameraForward().normalized * Time.deltaTime * moveSpeed/2.5f;
        vectVer.y = 0;
        camera.movePosition(-vectVer);
    }
    #endregion
}
