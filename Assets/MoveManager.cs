using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

    [SerializeField]
    Transform mainCamera;
    [SerializeField]
    Transform subCamera;

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
    public void MoveForward(Transform trans)
    {
        vectVer = trans.forward.normalized * Time.deltaTime * moveSpeed;
        vectVer.y = 0;
        trans.position += vectVer;
    }

    public void MoveRight(Transform trans)
    {
        vectHori = trans.right.normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        trans.position += vectHori;
    }

    public void MoveLeft(Transform trans)
    {
        vectHori = trans.right.normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        trans.position -= vectHori;
    }

    public void MoveBack(Transform trans) 
    {
        vectVer = trans.forward.normalized * Time.deltaTime * moveSpeed / 2.5f;
        vectVer.y = 0;
        trans.position -= vectVer;
    }
    #endregion
}
