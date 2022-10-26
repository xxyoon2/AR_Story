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
    private Ray _ray;
    private RaycastHit _hit;
    //private int layerMask;
    //private LayerMaskID layerMask;

    private Touch _touch;
    private Vector2 _tabPoint = new Vector2();

    public float _distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            return;
        }

        _touch = Input.GetTouch(0);

        switch (_touch.phase)
        {
            case TouchPhase.Began:
                Tab();
                break;
            case TouchPhase.Moved:
                if (_tabPoint.x >= 1050)
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
        _tabPoint = _touch.position;

        _ray = Camera.main.ScreenPointToRay(_touch.position);
        //Debug.Log($"{touch.position}");

        if (Physics.Raycast(_ray, out _hit, _distance, layerMask))
        {
            _hit.transform.GetComponent<Grass>()?.Catch();
            _hit.transform.GetComponent<NPC>()?.Talk();
            _hit.transform.GetComponent<QuestObject>()?.Catch();
            Debug.Log($"{_hit.transform.gameObject}");
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
