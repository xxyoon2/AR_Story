using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public interface IInput
{
    //public int LayerInfo(string layerName);
    public bool Tab(int layerMask);
    public bool Tab();
    public bool OpenBook();
}

public enum LayerMaskID
{
    OPENBOOK = 128,
}

public class TouchManager : MonoBehaviour, IInput
{
    private Ray ray;
    private RaycastHit hit;
    //private int layerMask;
    //private LayerMaskID layerMask;

    private Touch touch;
    private Vector2 tabPoint = new Vector2();

    public float distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            return;
        }

        touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                Tab();
                break;
            case TouchPhase.Moved:
                if (tabPoint.x >= 1050)
                {
                    OpenBook();
                }
                break;
            case TouchPhase.Ended:
                break;
        }
    }

    /*
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
    */

    // ��ġ�ؼ� ���� ������Ʈ�� �ִٸ� true, ���ٸ� false ��ȯ�ϴ� ���·� ��������
    public bool Tab()
    {
        return Tab(1);
    }

    public bool Tab(int layerMask)
    {
        tabPoint = touch.position;

        ray = Camera.main.ScreenPointToRay(touch.position);
        Debug.Log($"{touch.position}");

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            hit.transform.GetComponent<Grass>()?.Catch();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool OpenBook()
    {
        Debug.Log("��������");

        return true;
    }
}
