using System.Collections;
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
        if (anotherWorld)//subに移動するとき
        {
            Debug.Log("change");
            StartCoroutine(portalManager.MainPortalManage(!anotherWorld,0));
            StartCoroutine(portalManager.SubPortalManage(anotherWorld,0));

        }
        else
        {

            StartCoroutine(portalManager.SubPortalManage(anotherWorld,0));
            StartCoroutine(portalManager.MainPortalManage(!anotherWorld,0f));
        }
        //ChangeCamera(0.08f);
        subCamera.depth *= -1;
    }

    public void CallCreatePortal()
    {
        portalManager.CreatePortal(mainCamera.transform.position +=mainCamera.transform.forward*10f,mainCamera.transform.forward);
    }




}
