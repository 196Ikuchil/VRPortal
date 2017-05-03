using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraMaster : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //// TODO: ここで固定したい位置があれば指定しておく
        //Vector3 basePos = Vector3.zero;

        //// VR.InputTracking から hmd の位置を取得
        //Vector3 trackingPos =
        //        InputTracking.GetLocalPosition(VRNode.CenterEye);

        //// CameraController 自体の rotation が
        //// zero でなければ rotation を掛ける
        //// trackingPosition = trackingPos * transform.rotation;

        //// 固定したい位置から hmd の位置を
        //// 差し引いて実質 hmd の移動を無効化する
        //transform.position = basePos - trackingPos;

    }
}
