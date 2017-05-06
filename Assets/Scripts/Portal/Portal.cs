using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public PortalCamera portalCamera;
    private Material _portalMaterial;
    //微妙なブレによるcolliderの連続接触を禁止
    private bool cantChange=false;
    private float cantChangeTime = 0.7f;
    private float cantChangeTimer = 0;
    bool isSub;

    [SerializeField]
    public bool StartAmin=true;
    private Vector3 defaultSize;

	void Awake () {
        _portalMaterial = GetComponent<MeshRenderer>().sharedMaterial;
        if(this.gameObject.layer == 8)
        {
            isSub = true;
        }else
        {
            isSub = false;
        }
        if (StartAmin)
        {
            defaultSize = this.transform.parent.transform.localScale;
            this.transform.parent.transform.localScale = Vector3.zero;

        }
    }


    void Start()
    {
        if(StartAmin)
            StartCoroutine(Expand());
    }

    private IEnumerator Expand()
    {
        Vector3 adder = new Vector3(0.1f, 0.1f, 0.1f);
        GameObject parent = this.transform.parent.gameObject;
        while (true)
        {
            if (parent.transform.localScale.x > defaultSize.x) break;
            parent.transform.localScale += adder;
            yield return new WaitForEndOfFrame();

        }
    }

    void Update()
    {
        if (cantChange && cantChangeTimer>cantChangeTime)
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
        if (GameMaster.Instance.IsAnotherWorld() == isSub)
            portalCamera.RenderIntoMaterial(_portalMaterial);
    }

    void OnTriggerEnter(Collider col)
    {
        if (cantChange) return;
        if(col.tag == "MainCamera" )
        {
            GameMaster.Instance.ChangeWorld();
            cantChange = true;
            cantChangeTimer = 0;
        }
    }

    public void SetPortalCamera(PortalCamera camera)
    {
        portalCamera = camera;
    }
}
