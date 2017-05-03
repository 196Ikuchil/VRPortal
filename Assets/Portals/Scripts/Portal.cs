﻿using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public PortalCamera portalCamera;
    private Material _portalMaterial;

	void Awake () {
        _portalMaterial = GetComponent<MeshRenderer>().sharedMaterial;
	}
	
    private void OnWillRenderObject()
    {
        portalCamera.RenderIntoMaterial(_portalMaterial);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if(col.tag == "MainCamera")
        {
            GameMaster.Instance.ChangeWorld();
        }
    }
}
