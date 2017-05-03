using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour {

    public GameObject[] RenderTextureCameras;
    public GameObject[] Portals;
    Vector3 init;
    int _portalIndex;

    void Start()
    {

    }
    // Update is called once per frame
    void Update () {
        _portalIndex = 0;

        foreach(var camera in RenderTextureCameras) {
            //camera.transform.localPosition = transform.position - Portals[_portalIndex].transform.position;
            camera.transform.localPosition = - Portals[_portalIndex].transform.position;
            camera.transform.localRotation = transform.localRotation;
            _portalIndex++;
        }
	}
}
