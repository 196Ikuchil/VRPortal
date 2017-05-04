using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour {

    //public GameObject[] RenderTextureCameras;
    [SerializeField]
    GameObject mainRenderCamera;
    [SerializeField]
    GameObject subRenderCamera;
    public List<Portal> mainWorldPortals;
    public List<Portal> anotherWorldportals;

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
       // _portalIndex = 0;

        //foreach(var camera in RenderTextureCameras) {
            //camera.transform.localPosition = transform.position - Portals[_portalIndex].transform.position;
            //camera.transform.localPosition = - Portals[_portalIndex].transform.position;
            mainRenderCamera.transform.localPosition = Vector3.zero;//(transform.position - Portals[_portalIndex].transform.position);// * 0.2F;
            mainRenderCamera.transform.localRotation = mainCamera.transform.localRotation;//Quaternion.Euler((Portals[_portalIndex].transform.position - transform.position).z, 0, 0) * transform.localRotation;
                                                                                          // _portalIndex++;
        subRenderCamera.transform.localPosition = Vector3.zero;//(transform.position - Portals[_portalIndex].transform.position);// * 0.2F;
        subRenderCamera.transform.localRotation = mainCamera.transform.localRotation;//Quaternion.Euler((Portals[_portalIndex].transform.position - transform.position).z, 0, 0) * transform.localRotation;
                                                                            //}
    }

    /// <summary>
    /// 合わせ鏡的になると処理落ちするので、今のワールドのだけactiveにする
    /// </summary>
    public IEnumerator MainPortalManage(bool active,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach(Portal portal in mainWorldPortals)
        {
            portal.transform.parent.gameObject.SetActive(active);
        }
    }
    public IEnumerator SubPortalManage(bool active,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Portal portal in anotherWorldportals)
        {
            portal.transform.parent.gameObject.SetActive(active);
        }
    }

    /// <summary>
    /// とりあえずMainからよばれる体でつくる
    /// 指定したポジションにポータルを作成する
    /// </summary>
    public void CreatePortal(Vector3 position,Vector3 forward)
    {
        forward.y = 0;
        position.y = 0;
        var port =Instantiate(portalPref, position, Quaternion.identity);
        port.transform.eulerAngles = -forward;

        var parent = port.GetComponent<PortaParent>();
        mainWorldPortals.Add(parent.GetMainPortal());
        anotherWorldportals.Add(parent.GetSubPortal());
        parent.SetMainPortalCamera(subPortalCamera); //ここ逆に入れること(名前の設定ミス)
        parent.SetSubPortalCamera(mainPortalCamera);
    }
}
