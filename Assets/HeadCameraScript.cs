using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCameraScript : MonoBehaviour
{

    [SerializeField]
    Camera camera;

    public Vector3 GetCameraForward()
    {
        return camera.transform.forward;
    }

    public void movePosition(Vector3 pos)
    {
        this.transform.position += pos;
    }

    public Vector3 GetCameraRight()
    {
        return camera.transform.right;
    }
}



