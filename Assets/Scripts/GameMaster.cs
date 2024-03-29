﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;

public class GameMaster : SingletonMonoBehaviour<GameMaster> {

    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Camera subCamera;

    PortalManager portalManager;

    bool anotherWorld = false;
    public bool IsAnotherWorld()
    {
        return anotherWorld;
    }

	// Use this for initialization
	void Start () {
        portalManager = this.GetComponent<PortalManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.G))
        {
            CallCreatePortal();
        }
		
	}

    /// <summary>
    /// 使用するかめらを変更する
    /// </summary>
    public void ChangeWorld()
    {
        anotherWorld = !anotherWorld;
        StartCoroutine(portalManager.PortalVisibleManage(anotherWorld,0f));
        subCamera.depth *= -1;
    }

    /// <summary>
    /// TODO:仮実装
    /// 目線先の地面に作りたい
    /// </summary>
    public void CallCreatePortal()
    {
        portalManager.CreatePortal(mainCamera.transform.position+=mainCamera.transform.forward*5f,mainCamera.transform.forward);
    }




}
