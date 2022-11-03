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
    /// 화살표를 배치하는 오브젝트를 키는 함수
    /// </summary>
    /// <param name="routeNum">0 : 첫번째 루트, 1 : 두번째 루트, 2 : 세번째 루트</param>
    public void OnRoute(int routeNum)
    {
        _routes[routeNum].SetActive(true);
        Debug.Log($"{routeNum}번째 루트가 켜짐");
    }

    public void OffRoute(int routeNum)
    {
        _routes[routeNum].SetActive(false);
        Debug.Log($"{routeNum}번째 루트가 꺼짐");
    }
}
