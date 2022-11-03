using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    private GameObject[] _routes;

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            _routes[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _routes[i].SetActive(false);
        }
    }

    /// <summary>
    /// ȭ��ǥ�� ��ġ�ϴ� ������Ʈ�� Ű�� �Լ�
    /// </summary>
    /// <param name="routeNum">0 : ù��° ��Ʈ, 1 : �ι�° ��Ʈ, 2 : ����° ��Ʈ</param>
    public void OnRoute(int routeNum)
    {
        _routes[routeNum].SetActive(true);
        Debug.Log($"{routeNum}��° ��Ʈ�� ����");
    }

    public void OffRoute(int routeNum)
    {
        _routes[routeNum].SetActive(false);
        Debug.Log($"{routeNum}��° ��Ʈ�� ����");
    }
}
