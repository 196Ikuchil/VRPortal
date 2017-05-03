using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public Transform CameraRig;

    float _speed = 0.05f;

	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            MoveForward();
        }

        if (Input.GetKey(KeyCode.S)) {
            MoveBack();
        }

        if (Input.GetKey(KeyCode.D)) {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
        }
	}

    #region KeyBoardMove
    Vector3 vectVer;
    Vector3 vectHori;
    [SerializeField]
    float moveSpeed = 10;
    public void MoveForward()
    {
        vectVer = transform.forward.normalized * Time.deltaTime * moveSpeed;
        vectVer.y = 0;
        this.transform.position += vectVer;
    }

    public void MoveRight()
    {
        vectHori = transform.right.normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        this.transform.position += vectHori;
    }

    public void MoveLeft()
    {
        vectHori = transform.right.normalized * Time.deltaTime * moveSpeed / 2;
        vectHori.y = 0;
        this.transform.position -= vectHori;
    }

    public void MoveBack()
    {
        vectVer = transform.forward.normalized * Time.deltaTime * moveSpeed / 2.5f;
        vectVer.y = 0;
        this.transform.position -= vectVer;
    }
    #endregion
}
