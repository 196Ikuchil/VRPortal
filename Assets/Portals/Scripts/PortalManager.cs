using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour {

    public GameObject[] RenderTextureCameras;
    public GameObject[] Portals;
   
    int _portalIndex;
    Vector3 init;

    void Start()
    {
        init = transform.position;
    }

    // Update is called once per frame
    void Update () {
        _portalIndex = 0;

        foreach(var camera in RenderTextureCameras) {
            //camera.transform.localPosition = transform.position - Portals[_portalIndex].transform.position;
            //camera.transform.localPosition = - Portals[_portalIndex].transform.position;
            camera.transform.localPosition = (transform.position - Portals[_portalIndex].transform.position) * 0.2F;
            camera.transform.localRotation = Quaternion.Euler((Portals[_portalIndex].transform.position - transform.position).x, 0, 0);// * transform.localRotation;
            _portalIndex++;
        }
	}
}
