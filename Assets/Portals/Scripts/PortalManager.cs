using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour {

    public GameObject[] RenderTextureCameras;
    public List<GameObject> mainWorldPortals;
    public List<GameObject> anotherWorldportals;
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
        _portalIndex = 0;

        foreach(var camera in RenderTextureCameras) {
            //camera.transform.localPosition = transform.position - Portals[_portalIndex].transform.position;
            //camera.transform.localPosition = - Portals[_portalIndex].transform.position;
            camera.transform.localPosition = Vector3.zero;//(transform.position - Portals[_portalIndex].transform.position);// * 0.2F;
            camera.transform.localRotation = mainCamera.transform.localRotation;//Quaternion.Euler((Portals[_portalIndex].transform.position - transform.position).z, 0, 0) * transform.localRotation;
            _portalIndex++;
        }
	}

    /// <summary>
    /// 合わせ鏡的になると処理落ちするので、今のワールドのだけactiveにする
    /// </summary>
    public IEnumerator MainPortalManage(bool active,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach(GameObject portal in mainWorldPortals)
        {
            portal.SetActive(active);
        }
    }
    public IEnumerator SubPortalManage(bool active,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (GameObject portal in anotherWorldportals)
        {
            portal.SetActive(active);
        }
    }

    /// <summary>
    /// とりあえずMainからよばれる体でつくる
    /// </summary>
    public void CreatePortal()
    {

    }
}
