using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public interface IInput
{
    public int LayerInfo(string layerName);
    public bool Tab(int layerMask);
    public bool Tab();
    public void Drag();
}

public class TouchManager : MonoBehaviour, IInput
{

    private Ray ray;
    private RaycastHit hit;
    private int layerMask;

    public float distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        layerMask = LayerInfo("Object");

        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (Tab(layerMask))
                {
                    //hit.transform.GetComponent<Tiger>()?.Die();
                }
                break;
            case TouchPhase.Moved:
                if (Tab(layerMask))
                {
                    // ������Ʈ �����̱� ���� �ڷ�ƾ ȣ��
                    // �ٵ� ���� �ڷ�ƾ�� �ʿ��ұ�...?
                }
                break;
            case TouchPhase.Ended:
                if (Tab(layerMask))
                {
                    // ����  phase�� move���ٸ� �ڷ�ƾ �ߴ�
                }
                break;
        }

        /*
        // ��ġ
        if (touch.phase == TouchPhase.Began)
        {
            layerMask = LayerInfo("Object");
            if (Tab(layerMask))
            {
                hit.transform.GetComponent<Tiger>()?.Die();
            }
        }
        //�巡��
        if (touch.phase == TouchPhase.Moved)
        {
            layerMask = LayerInfo("Default");
            if (Tab(layerMask))
        }

        if (touch.)
        */
    }

    /// <summary>
    /// �� ��° ���̾����� ��ȯ
    /// </summary>
    /// <param name="layerName">���̾� �̸�</param>
    /// <returns></returns>
    public int LayerInfo(string layerName)
    {
        // ���߿��� �޼��尡 �ƴ϶� class�� ����ؾ��� �ִϸ��̼� �̸� �����صΰ� �� ��
        // ex ) ������ ����� AnimID class ����
        layerMask = 1 << LayerMask.NameToLayer(layerName);

        return layerMask;
    }

    // ��ġ�ؼ� ���� ������Ʈ�� �ִٸ� true, ���ٸ� false ��ȯ�ϴ� ���·� ��������
    public bool Tab()
    {
        return Tab(1);
    }

    public bool Tab(int layerMask)
    {
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Drag()
    {

    }

    /*
    // ������ ��ü
    private GameObject placeObject;
    private ARRaycastManager raycastMgr;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        // ������ ť�� �Ҵ�
        placeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // ť�� ũ�� ����
        placeObject.transform.localScale = Vector3.one * 0.05f;
        // AR Raycast Manager ����
        raycastMgr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // ������� �ν��� ���� ���̷� ����
            if (raycastMgr.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(placeObject, hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }

    */
}
