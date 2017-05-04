using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaParent : MonoBehaviour {

    [SerializeField]
    Portal mainPortal;
    [SerializeField]
    Portal subPortal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Portal GetMainPortal()
    {
        return mainPortal;
    }
   public  Portal GetSubPortal()
    {
        return subPortal;
    }

    public void SetMainPortalCamera(PortalCamera camera)
    {
        GetMainPortal().SetPortalCamera(camera);
    }

    public void SetSubPortalCamera(PortalCamera camera)
    {
        GetSubPortal().SetPortalCamera(camera);
    }
}
