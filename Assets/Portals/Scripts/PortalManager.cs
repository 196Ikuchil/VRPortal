using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour {

    [SerializeField]
    List<PortaParent> portalParents;

    [SerializeField]
    PortalCamera mainPortalCamera;
    [SerializeField]
    PortalCamera subPortalCamera;

    [SerializeField]
    GameObject mainCamera;


    [SerializeField]
    GameObject portalPref;
   
    int _portalIndex;

    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
        mainPortalCamera.GetMyPortalCamera().transform.localPosition = Vector3.zero;
        mainPortalCamera.GetMyPortalCamera().transform.localRotation = mainCamera.transform.localRotation;

        subPortalCamera.GetMyPortalCamera().transform.localPosition = Vector3.zero;
        subPortalCamera.GetMyPortalCamera().transform.localRotation = mainCamera.transform.localRotation;
    }


    public IEnumerator PortalVisibleManage(bool anotherWorld,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (PortaParent parent in portalParents)
        {
            parent.SetPortalvisible(anotherWorld);
        }

    }

    /// <summary>
    /// 指定したポジションにポータルを作成する
    /// </summary>
    public void CreatePortal(Vector3 position,Vector3 forward)
    {
        forward.y = 0;
        position.y = 0;

        var parent =Instantiate(portalPref, position, Quaternion.identity).GetComponent<PortaParent>();
        parent.transform.forward = forward;

        portalParents.Add(parent);
        parent.SetPortalCamera(mainPortalCamera,subPortalCamera);

        if (GameMaster.Instance.IsAnotherWorld())//subなら
        {
            parent.transform.forward = -forward;
            parent.SetPortalvisible(true);
        }
    }
}
