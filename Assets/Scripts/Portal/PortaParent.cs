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
        //浮遊感
        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 01f), transform.position.z);
    }

    public Portal GetMainPortal()
    {
        return mainPortal;
    }
   public  Portal GetSubPortal()
    {
        return subPortal;
    }

    void SetMainPortalCamera(PortalCamera camera)
    {
        GetMainPortal().SetPortalCamera(camera);
    }

    void SetSubPortalCamera(PortalCamera camera)
    {
        GetSubPortal().SetPortalCamera(camera);
    }

    /// <summary>
    /// 個々の持つポータルの可視を設定する
    /// trueならsubの世界にいるということ
    /// </summary>
    /// <param name="anotherWorld"></param>
    public void SetPortalvisible(bool anotherWorld)
    {
        if(anotherWorld) //subにいる
        {
            mainPortal.gameObject.SetActive(false);
            mainPortal.StartAmin = false;
            mainPortal.transform.parent.gameObject.SetActive(false);
            subPortal.transform.parent.gameObject.SetActive(true);
            subPortal.gameObject.SetActive(true);
            subPortal.StartAmin = true;
        }
        else
        {
            mainPortal.transform.parent.gameObject.SetActive(true);
            mainPortal.gameObject.SetActive(true);
            mainPortal.StartAmin = true;
            subPortal.gameObject.SetActive(false);
            subPortal.StartAmin = false;
            subPortal.transform.parent.gameObject.SetActive(false);
        }

    }

    public void SetPortalCamera(PortalCamera main,PortalCamera sub)
    {
        SetMainPortalCamera(sub); //名前のつけ方みすった
        SetSubPortalCamera(main);
    }
}
