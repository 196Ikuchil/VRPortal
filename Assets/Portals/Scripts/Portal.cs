using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public PortalCamera portalCamera;
    private Material _portalMaterial;
    //微妙なブレによるcolliderの連続接触を禁止
    private bool cantChange=false;
    private float cantChangeTime = 0.5f;
    private float cantChangeTimer = 0;
	void Awake () {
        _portalMaterial = GetComponent<MeshRenderer>().sharedMaterial;
	}
    void Update()
    {
        if (cantChangeTimer>cantChangeTime)
        {
            cantChange = false;
        }
        else if (cantChange)
        {
            cantChangeTimer += Time.deltaTime;
        }
    }
	
    private void OnWillRenderObject()
    {
        portalCamera.RenderIntoMaterial(_portalMaterial);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (cantChange) return;
        if(col.tag == "MainCamera" )
        {
            GameMaster.Instance.ChangeWorld();
            cantChange = true;
            cantChangeTimer = 0;
        }
    }
}
